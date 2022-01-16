using System;
using System.Numerics;

namespace DigitalSignalProcessing
{
    /// <summary>
    /// Standard windowed-sinc lowpass filter with a single cutoff frequency
    /// </summary>
    public class LowPassFilter
    {
        public double CutoffFrequency { get; private set; }
        public int M { get; private set; }
        public double[] Kernel { get; private set; }

        /// <summary>
        /// Windowed-Sinc lowpass filter with cutoff frequency of fc and total kernel length of M.
        /// </summary>
        /// <param name="fc">Cutoff frequency</param>
        /// <param name="M">Length of kernel</param>
        public LowPassFilter(double fc, int M)
        {
            GuardClauses.IsOutsideLimits(nameof(LowPassFilter), nameof(fc), fc, 0, 0.5);
            GuardClauses.IsLessThan(nameof(LowPassFilter), nameof(M), M, 0);
            GuardClauses.IsEven(nameof(LowPassFilter), nameof(M), M);

            CutoffFrequency = fc;
            this.M = M;
            Kernel = DSP.WindowedSinc(M, fc);
        }

        /// <summary>
        /// Filters an input seuqence using ether convolution or FFT depending on length of the filter.
        /// </summary>
        /// <param name="input">input sequence to be filtered</param>
        /// <returns>filtered sequence</returns>
        public double[] Filter(double[] input)
        {
            int minKernelSize = Math.Min(input.Length, Kernel.Length);
            double[] output;

            if(minKernelSize <= 64)
            {
                // do regular convolution
                output = DSP.TruncConv(input, Kernel);
            }
            else
            {
                // do FFT convolution
                int paddingLength = DSP.NextLargestPowerOfTwo(Math.Max(input.Length, Kernel.Length));
                double[] paddedInput = DSP.ZeroPad(input, paddingLength);
                double[] paddedKernel = DSP.ZeroPad(Kernel, paddingLength);
                Complex[] X = DSP.FFT(paddedInput);
                Complex[] K = DSP.FFT(paddedKernel);

                for(int i = 0; i < X.Length; i++)
                {
                    X[i] = X[i] * K[i];
                }

                output = DSP.Real(DSP.IFFT(X));
            }

            return output;
        }

        /// <summary>
        /// Returns the frequency response of the filter.
        /// </summary>
        /// <param name="length">Length of the frequency response. Should be a power of two.</param>
        /// <returns>Complex sequence containing frequency response of the filter</returns>
        public Complex[] FrequencyResponse(int length = 1024)
        {
            GuardClauses.IsLessThan(nameof(FrequencyResponse), nameof(length), length, Kernel.Length);
            int nextPow = DSP.NextLargestPowerOfTwo(length);
            Complex[] freqZ;

            if(length == nextPow)
            {
                // use FFT
                freqZ = DSP.FFT(DSP.ZeroPad(Kernel, length));
            }
            else
            {
                // use DFT *SLOW*
                freqZ = DSP.DFT(DSP.ZeroPad(Kernel, length));
            }

            return freqZ;
        }
    }
}
