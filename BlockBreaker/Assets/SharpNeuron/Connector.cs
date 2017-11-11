﻿using SharpNeuron.Initializers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SharpNeuron
{
    /// <summary>
    /// A connector represents a collection of synapses connecting two layers in a network.
    /// </summary>
    /// <typeparam name="TSourceLayer">Type of Source Layer</typeparam>
    /// <typeparam name="TTargetLayer">Type of Target Layer</typeparam>
    /// <typeparam name="TSynapse">Type of Synapse</typeparam>

    public abstract class Connector<TSourceLayer, TTargetLayer, TSynapse> : IConnector
        where TSourceLayer : ILayer
        where TTargetLayer : ILayer
        where TSynapse : ISynapse
    {
        /// <summary>
        /// The source layer. It is initialized in constructor and is never changed later. It is
        /// never <c>null</c>.
        /// </summary>
        protected readonly TSourceLayer sourceLayer;

        /// <summary>
        /// The target layer. It is initialized in constructor and is never changed later. It is
        /// never <c>null</c>.
        /// </summary>
        protected readonly TTargetLayer targetLayer;

        /// <summary>
        /// Array of synapses in the connector. It is never <c>null</c>.
        /// </summary>
        protected readonly TSynapse[] synapses;

        /// <summary>
        /// The mode of connection (One-one or Complete). It is initialized in the constructor and
        /// is immutable.
        /// </summary>
        protected readonly ConnectionMode connectionMode;

        /// <summary>
        /// Initializer used to initialize the connector
        /// </summary>
        protected IInitializer initializer;

        /// <summary>
        /// Gets the source layer
        /// </summary>
        /// <value>
        /// The source layer. It is never <c>null</c>.
        /// </value>
        public TSourceLayer SourceLayer
        {
            get { return sourceLayer; }
        }

        /// <summary>
        /// Gets the target layer
        /// </summary>
        /// <value>
        /// The target layer. It is never <c>null</c>.
        /// </value>
        public TTargetLayer TargetLayer
        {
            get { return targetLayer; }
        }

        /// <summary>
        /// Gets the number of synapses in the connector.
        /// </summary>
        /// <value>
        /// Synapse Count. It is always positive.
        /// </value>
        public int SynapseCount
        {
            get { return synapses.Length; }
        }

        /// <summary>
        /// Exposes an enumerator to iterate over all synapses in the connector.
        /// </summary>
        /// <value>
        /// Synapses Enumerator. No synapse enumerated can be <c>null</c>.
        /// </value>
        public IEnumerable<TSynapse> Synapses
        {
            get
            {
                for (int i = 0; i < synapses.Length; i++)
                {
                    yield return synapses[i];
                }
            }
        }

        ILayer IConnector.SourceLayer
        {
            get { return sourceLayer; }
        }

        ILayer IConnector.TargetLayer
        {
            get { return targetLayer; }
        }

        IEnumerable<ISynapse> IConnector.Synapses
        {
            get
            {
                for (int i = 0; i < synapses.Length; i++)
                {
                    yield return synapses[i];
                }
            }
        }

        /// <summary>
        /// Gets the connection mode
        /// </summary>
        /// <value>
        /// Connection Mode
        /// </value>
        public ConnectionMode ConnectionMode
        {
            get { return connectionMode; }
        }

        /// <summary>
        /// Gets or sets the Initializer used to initialize the connector
        /// </summary>
        /// <value>
        /// Initializer used to initialize the connector. If this value is <c>null</c>, initialization
        /// is NOT performed.
        /// </value>
        public IInitializer Initializer
        {
            get { return initializer; }
            set { initializer = value; }
        }

        /// <summary>
        /// Creates a new connector between given layers using the connection mode specified.
        /// </summary>
        /// <param name="sourceLayer">
        /// the source layer
        /// </param>
        /// <param name="targetLayer">
        /// the target layer
        /// </param>
        /// <param name="connectionMode">
        /// connection mode to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>sourceLayer</c> or <c>targetLayer</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <c>connectionMode</c> is invalid
        /// </exception>
        protected Connector(TSourceLayer sourceLayer, TTargetLayer targetLayer, ConnectionMode connectionMode)
        {
            // Validate
            //Helper.ValidateNotNull(sourceLayer, nameof(sourceLayer));
            //Helper.ValidateNotNull(targetLayer, nameof(targetLayer));

            targetLayer.SourceConnectors.Add(this);
            sourceLayer.TargetConnectors.Add(this);

            this.sourceLayer = sourceLayer;
            this.targetLayer = targetLayer;
            this.connectionMode = connectionMode;
            initializer = new NguyenWidrowFunction();

            // Since synapses array is readonly, it should be initialized here
            switch (connectionMode)
            {
                case ConnectionMode.AllToAll:
                case ConnectionMode.AllToElse:
                    synapses = new TSynapse[sourceLayer.NeuronCount * targetLayer.NeuronCount];
                    break;

			case ConnectionMode.OneToOne:
				if (sourceLayer.NeuronCount == targetLayer.NeuronCount) {
					synapses = new TSynapse[sourceLayer.NeuronCount];
					break;
				}
				throw new ArgumentException (
					"One-One connector cannot be formed between these layers");//, nameof(connectionMode));
			default:
				throw new ArgumentException ("Invalid Connection Mode");//, nameof(connectionMode));
            }
        }

        /// <summary>
        /// Adds small random noise to weights of synapses so that the network deviates from its
        /// local optimum position (a local equilibrium state where further learning is of no use)
        /// </summary>
        /// <param name="jitterNoiseLimit">
        /// Maximum absolute limit to the random noise added
        /// </param>
        public void Jitter(double jitterNoiseLimit)
        {
            for (int i = 0; i < synapses.Length; i++)
            {
                synapses[i].Jitter(jitterNoiseLimit);
            }
        }

        /// <summary>
        /// Gets a enumerator to a collection of source synapses of the neuron which belong to this
        /// connector
        /// </summary>
        /// <param name="neuron">
        /// Neuron
        /// </param>
        /// <returns>
        /// An enumerator to a collection of source synapses of the neuron which belong to this
        /// connector
        /// </returns>
        public IEnumerable<TSynapse> GetSourceSynapses(INeuron neuron)
        {
            foreach (TSynapse synapse in neuron.SourceSynapses)
            {
                if (synapse.Parent == this)
                {
                    yield return synapse;
                }
            }
        }

        /// <summary>
        /// Gets a enumerator to a collection of target synapses of the neuron which belong to this
        /// connector
        /// </summary>
        /// <param name="neuron">
        /// Neuron
        /// </param>
        /// <returns>
        /// An enumerator to a collection of target synapses of the neuron which belong to this
        /// connector
        /// </returns>
        public IEnumerable<TSynapse> GetTargetSynapses(INeuron neuron)
        {
            foreach (TSynapse synapse in neuron.TargetSynapses)
            {
                if (synapse.Parent == this)
                {
                    yield return synapse;
                }
            }
        }

        /// <summary>
        /// Initializes all synapses in the connector and makes them ready to undergo training
        /// freshly. (Adjusts the weights of synapses using the initializer)
        /// </summary>
        public abstract void Initialize();
    }
}