using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DigitalSignalProcessing
{
    public static class DSP
    {
        /// <summary>
        /// Calculates the mean and sample standard deviation of a signal.
        /// </summary>
        public static (double mean, double std) CalcMeanStd(double[] x)
        {
            double sum = 0;
            double sumSquares = 0;
            int N = x.Length;
            if(N == 0) { return (0, 0); }

            for(int i = 0; i < N; i++)
            {
                sum += x[i];
                sumSquares += x[i] * x[i];
            }

            double mean = sum / N;
            double std = (sumSquares - sum * sum / N) / (N - 1);
            std = Math.Sqrt(std);

            return (mean, std);
        }

        /// <summary>
        /// Calculates the mean and sample standard deviation of a signal.
        /// </summary>
        public static (double mean, double std) CalcMeanStd(int[] x)
        {
            double sum = 0;
            double sumSquares = 0;
            int N = x.Length;
            if (N == 0) { return (0, 0); }

            for (int i = 0; i < N; i++)
            {
                sum += x[i];
                sumSquares += x[i] * x[i];
            }

            double mean = sum / N;
            double std = (sumSquares - sum * sum / N) / (N - 1);
            std = Math.Sqrt(std);

            return (mean, std);
        }

        /// <summary>
        /// Calculates the histogram of a signal where first bin in histogram corresponds to total count of the min value
        /// and the last bin corresponds to the total count for the max value.
        /// </summary>
        public static (int[] hist, int minVal, int maxVal) CalcHist(int[] x)
        {
            int minVal = x.Min();
            int maxVal = x.Max();

            int bins = maxVal - minVal + 1;
            int[] hist = new int[bins];

            for(int i = 0; i < x.Length; i++)
            {
                hist[x[i] - minVal]++;
            }

            return (hist, minVal, maxVal);
        }

        /// <summary>
        /// Calculates the binned histogram of a signal of doubles. 
        /// </summary>
        public static (int[] hist, double minVal, double maxVal) CalcHist(double[] x, int bins)
        {
            int[] hist = new int[bins];
            double minVal = x.Min();
            double maxVal = x.Max();

            double step = (maxVal - minVal) / bins;
            int bin;

            for(int i = 0; i < x.Length; i++)
            {
                bin = (int)((x[i] - minVal) * step);
                bin = bin >= bins ? bins - 1 : bin;
                hist[bin]++;
            }

            return (hist, minVal, maxVal);
        }

        /// <summary>
        /// Calculates the even decomposition of a signal
        /// </summary>
        public static double[] EvenDecompose(double[] x)
        {
            GuardClauses.IsOdd(nameof(EvenDecompose), $"length of {nameof(x)}", x.Length);

            int N = x.Length;
            double[] xE = new double[N];

            xE[0] = x[0];

            for(int i = 1; i < x.Length; i++)
            {
                xE[i] = (x[i] + x[N - i]) / 2;
            }

            return xE;
        }

        /// <summary>
        /// Calculates the odd decomposition of signal
        /// </summary>
        public static double[] OddDecompose(double[] x)
        {
            GuardClauses.IsOdd(nameof(OddDecompose), $"length of {nameof(x)}", x.Length);

            int N = x.Length;
            double[] xO = new double[N];

            xO[0] = 0;

            for(int i = 1; i < x.Length; i++)
            {
                xO[i] = (x[i] - x[N - i]) / 2;
            }

            return xO;
        }

        /// <summary>
        /// Convolves a signal x with kernel h
        /// </summary>
        public static double[] NaiveConv(double[] x, double[] h)
        {
            if(h.Length > x.Length) { return NaiveConv(h, x); }

            int N = x.Length;
            int M = h.Length;
            int L = N + M - 1;
            double[] y = new double[L];

            for(int i = 0; i < L; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if (i - j < 0) continue;
                    if (i - j >= N) continue;
                    y[i] += h[j] * x[i - j];
                }
            }

            return y;
        }

        /// <summary>
        /// Optimized 1D convolution that avoids boundary checks with each loop. Convolves an input x with a kernel h.
        /// </summary>
        public static double[] OptimConv(double[] x, double[] h)
        {
            if(h.Length > x.Length) { return OptimConv(h, x); }

            int N = x.Length;
            int M = h.Length;
            int L = N + M - 1;
            double[] y = new double[L];

            for(int i = 0; i < M - 1; i++)
            {
                double sum = 0;

                for(int j = 0; j < i + 1; j++)
                {
                    sum += h[j] * x[i - j];
                }

                y[i] = sum;
            }

            for(int i = M - 1; i < L - M + 1; i++)
            {
                double sum = 0;

                for(int j = 0; j < M; j++)
                {
                    sum += h[j] * x[i - j];
                }

                y[i] = sum;
            }

            for(int i = L - M + 1; i < L; i++)
            {
                double sum = 0;

                for(int j = i - L + M; j < M; j++)
                {
                    sum += h[j] * x[i - j];
                }

                y[i] = sum;
            }

            return y;
        }

        /// <summary>
        /// Generates a Hamming window sequence of total length M + 1
        /// </summary>
        public static double[] Hamming(int M)
        {
            double[] window = new double[M + 1];

            for(int i = 0; i <= M; i++)
            {
                window[i] = 0.54 - 0.46 * Math.Cos(2 * Math.PI * i / M);
            }

            return window;
        }

        /// <summary>
        /// Generates a Blackman window sequence of total length M + 1
        /// </summary>
        public static double[] Blackman(int M)
        {
            double[] window = new double[M + 1];

            for(int i = 0; i <= M; i++)
            {
                window[i] = 0.42 - 0.5 * Math.Cos(2 * Math.PI * i / M) + 0.08 * Math.Cos(4 * Math.PI * i / M);
            }

            return window;
        }

        /// <summary>
        /// Generates a rectangle sequence of length M where L samples equals the given starting at the specified delay point.
        /// </summary>
        public static double[] Rectangle(int L, int M, int delay, double magnitude = 1)
        {
            double[] rectSequence = new double[M];

            int stopIdx = Math.Min(M, delay + L + 1);

            for(int i = delay; i < stopIdx; i++)
            {
                rectSequence[i] = magnitude;
            }

            return rectSequence;
        }

        /// <summary>
        /// Generates an impulse sequence with a given magnitude and delay. All samples are zero except at the given delay timepoint,
        /// where the sequence has a value equal to the given magnitude.
        /// </summary>
        public static double[] Impulse(int length, double magnitude = 1, int delay = 0)
        {
            GuardClauses.IsOutOfBounds(nameof(Impulse), nameof(delay), nameof(length), delay, length);

            double[] impulse = new double[length];
            impulse[delay] = magnitude;
            return impulse;
        }

        /// <summary>
        /// Generates a step sequence where all samples after the given delay are equal to the given magnitude.
        /// </summary>
        public static double[] Step(int length, double magnitude = 1, int delay = 0)
        {
            GuardClauses.IsOutOfBounds(nameof(Step), nameof(delay), nameof(length), delay, length);

            double[] step = new double[length];

            for(int i = delay; i < length; i++)
            {
                step[i] = magnitude;
            }

            return step;
        }

        /// <summary>
        /// Calculates the moving average of sequence x with given box size. Box size must be odd.
        /// </summary>
        public static double[] AverageFilter(double[] x, int boxSize)
        {
            GuardClauses.IsEven(nameof(AverageFilter), nameof(boxSize), boxSize);
            GuardClauses.IsLessThan(nameof(AverageFilter), nameof(boxSize), boxSize, 0);

            int N = x.Length;
            int halfSize = boxSize / 2;
            int Nprime = x.Length - halfSize;
            double[] y = new double[x.Length];

            for(int i = 0; i < halfSize; i++)
            {
                double sum = 0.0;

                for(int j = 0; j < i + halfSize + 1; j++)
                {
                    sum += x[i + j];
                }

                y[i] = sum / boxSize;
            }

            for(int i = halfSize; i < Nprime; i++)
            {
                double sum = 0.0;

                for(int j = i - halfSize; j < i + halfSize + 1; j++)
                {
                    sum += x[i + j];
                }

                y[i] = sum / boxSize;
            }

            for(int i = Nprime; i < N; i++)
            {
                double sum = 0.0;

                for(int j = i - halfSize; j < N; j++)
                {
                    sum += x[i + j];
                }

                y[i] = sum / boxSize;
            }

            return y;
        }
    }
}
