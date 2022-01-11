using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
