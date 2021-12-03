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

        public static double Rand(double max)
        {
            return rng.NextDouble() * max;
        }

        public static double Rand(double min, double max)
        {
            return (rng.NextDouble() * (max - min)) + min;
        }

        public static double SampleNormalDist(double mean = 0, double std = 1)
        {
            double x = Math.Sqrt(-2 * Math.Log(rng.NextDouble())) * Math.Cos(2 * Math.PI * rng.NextDouble());
            return mean == 0 && std == 1 ? x : (x * std) + mean;
        }
    }
}
