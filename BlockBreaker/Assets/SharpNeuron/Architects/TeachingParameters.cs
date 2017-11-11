namespace SharpNeuron.Architects
{
    public class TeachingParameters
    {
		private int iterations = 20000;
        /// <summary>
        /// The maximum number of iterations to train the network for
        /// </summary>
        public int Iterations { 
			get{ return this.iterations; }
			set{ this.iterations = value; }
		}

		private double errorThreshold = 0.005;
        /// <summary>
        /// The threshold of error at which to stop training the network. If the error of the network is below this threshold, teaching stops, even if not all of the iterations are finished. Set this to 0 to have the teacher always train for all the iterations
        /// </summary>
        public double ErrorThreshold { 
			get{ return errorThreshold; }
			set{ this.errorThreshold = value; }
		}

        /// <summary>
        /// The rate at which the network should learn
        /// </summary>
        private double learningRate = 0.3;
		public double LearningRate { 
			get{ return learningRate; }
			set{ this.learningRate = value; }
		}
    }
}