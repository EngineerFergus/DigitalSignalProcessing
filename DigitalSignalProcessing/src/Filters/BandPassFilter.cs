using System;
using System.Numerics;

namespace DigitalSignalProcessing.src.Filters
{
    public class BandPassFilter : IFilter
    {
        public double CutoffFrequencyOne { get; private set; }
        public double CutoffFrequencyTwo { get; private set; }
        public int M { get; private set; }
        public double[] Kernel { get; private set; }

        /// <summary>
        /// Windowed-sinc bandpass filter made using a combination of a low and high pass filters
        /// </summary>
        /// <param name="fcOne">first cutoff frequency</param>
        /// <param name="fcTwo">second cutoff frequency</param>
        /// <param name="M">length of filter kernel</param>
        public BandPassFilter(double fcOne, double fcTwo, int M)
        {
            GuardClauses.IsOutsideLimits(nameof(BandPassFilter), nameof(fcOne), fcOne, 0, 0.5);
            GuardClauses.IsOutsideLimits(nameof(BandPassFilter), nameof(fcTwo), fcTwo, 0, 0.5);
            GuardClauses.IsLessThan(nameof(BandPassFilter), nameof(M), M, 0);
            GuardClauses.IsEven(nameof(BandPassFilter), nameof(M), M);

            CutoffFrequencyOne = Math.Min(fcOne, fcTwo);
            CutoffFrequencyTwo = Math.Max(fcOne, fcTwo);
            this.M = M;
            Kernel = DSP.WindowedSinc(M, CutoffFrequencyOne);
            double[] temp = DSP.SpectralInversion(DSP.WindowedSinc(M, CutoffFrequencyTwo));

            for(int i = 0; i < Kernel.Length; i++)
            {
                Kernel[i] += temp[i];
            }

            Kernel = DSP.SpectralInversion(Kernel);
        }

        /// <summary>
        /// Filters an input sequence using either convolution or FFT depending on length of the filter.
        /// </summary>
        /// <param name="input">input sequence to be filtered</param>
        /// <returns>filtered sequence</returns>
        public double[] Filter(double[] input)
        {
            int minKernelSize = Math.Min(input.Length, Kernel.Length);
            double[] output;

            if (minKernelSize <= 64)
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

                for (int i = 0; i < X.Length; i++)
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

            if (length == nextPow)
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
