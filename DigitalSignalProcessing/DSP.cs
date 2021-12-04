using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalProcessing
{
    public static class DSP
    {
        /// <summary>
        /// Calculates the mean and standard deviation of a signal.
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
        /// Calculates the mean and standard deviation of a signal.
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
                hist[x[i]]++;
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
                bin = (int)(x[i] * step);
                hist[bin]++;
            }

            return (hist, minVal, maxVal);
        }
        /// <summary>
        /// Calculates the even decomposition of a signal
        /// </summary>
        public static double[] EvenDecompose(double[] x)
        {
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
        public static double[] Conv(double[] x, double[] h)
        {
            double[] filter;
            double[] input;

            if(x.Length >= h.Length)
            {
                input = x;
                filter = h;
            }
            else
            {
                input = h;
                filter = x;
            }

            int L1 = input.Length;
            int L2 = filter.Length;
            int L3 = L1 + L2 - 1;
            double[] y = new double[L3];

            //for(int i = 0; i < L3; i++)
            //{
            //
            //    double sum = 0;
            //    int n1 = i < L1 ? 0 : i - L1 + 1;
            //    int n2 = i < L2 ? i : L2 - 1;
            //
            //    for (int j = n1; j <= n2; j++)
            //    {
            //        sum += input[i - j] * filter[j];
            //    }
            //    y[i] = sum;
            //}

            for(int i = 0; i < L2; i++)
            {
                double sum = 0;
                for(int j = i; j >= 0; j--)
                {
                    sum += input[i - j] * filter[j];
                }
                y[i] = sum;
            }

            for(int i = L2; i < L1; i++)
            {
                double sum = 0;
                for(int j = L2; j >= 0; j--)
                {
                    sum += input[i - j] * filter[j];
                }
                y[i] = sum;
            }

            for(int i = L1; i < L3; i++)
            {
                double sum = 0;
                for(int j = i - L1 + 1; j < L1; j++)
                {
                    sum += input[i - j] * filter[j];
                }
                y[i] = sum;
            }

            return y;
        }
    }
}
