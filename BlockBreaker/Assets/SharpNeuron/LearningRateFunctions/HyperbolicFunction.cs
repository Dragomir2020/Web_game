﻿namespace SharpNeuron.LearningRateFunctions
{
    /// <summary>
    /// Hyperbolic Learning Rate Function. As training progresses, The learning rate hyperbolically
    /// changes from its initial value to the final value.
    /// </summary>
    public sealed class HyperbolicFunction : AbstractFunction
    {
        private readonly double product;

        /// <summary>
        /// Constructs a new instance of the hyperbolic function with the specified initial and
        /// final values of learning rate.
        /// </summary>
        /// <param name="initialLearningRate">
        /// Initial value learning rate
        /// </param>
        /// <param name="finalLearningRate">
        /// Final value learning rate
        /// </param>
        public HyperbolicFunction(double initialLearningRate, double finalLearningRate)
            : base(initialLearningRate, finalLearningRate)
        {
            product = initialLearningRate * finalLearningRate;
        }

        /// <summary>
        /// Gets effective learning rate for current training iteration. (As training progresses, The
        /// learning rate hyperbolically changes from its initial value to the final value)
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <returns>
        /// The effective learning rate for current training iteration
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        public override double GetLearningRate(int currentIteration, int trainingEpochs)
        {
            Helper.ValidatePositive(trainingEpochs, "trainingEpochs");
            Helper.ValidateWithinRange(currentIteration, 0, trainingEpochs - 1, "currentIteration");

            double denominator = finalLearningRate
                + ((initialLearningRate - finalLearningRate) * currentIteration) / trainingEpochs;

            if (denominator == 0)
            {
                return 0d;
            }
            return product / denominator;
        }
    }
}