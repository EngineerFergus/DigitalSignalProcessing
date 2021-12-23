using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalProcessing
{
    public static class RNG
    {
        private static int seed;
        private static Random rng;
        /// <summary>
        /// Reseeds the Random Number Generator with the given seed value.
        /// </summary>
        public static void Seed(int s)
        {
            seed = s;
            rng = new Random(seed);
        }

        static RNG()
        {
            seed = (int)DateTime.Now.Ticks;
            rng = new Random(seed);
        }
        /// <summary>
        /// Returns a random number between zero and the given maximum value.
        /// </summary>
        public static double Rand(double max)
        {
            return rng.NextDouble() * max;
        }
        /// <summary>
        /// Returns a random number between the minimum and maximum values given.
        /// </summary>
        public static double Rand(double min, double max)
        {
            return (rng.NextDouble() * (max - min)) + min;
        }
        /// <summary>
        /// Returns a sample from a Normal (Gaussian) Distribution with a given mean and standard deviation.
        /// Uses the Box-Muller transform to generate the samples.
        /// </summary>
        public static double SampleNormalDistribution(double mean = 0, double std = 1)
        {
            double x = Math.Sqrt(-2 * Math.Log(rng.NextDouble())) * Math.Cos(2 * Math.PI * rng.NextDouble());
            return mean == 0 && std == 1 ? x : (x * std) + mean;
        }
    }
}
