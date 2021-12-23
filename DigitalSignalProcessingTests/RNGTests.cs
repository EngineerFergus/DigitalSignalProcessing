using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;

namespace DigitalSignalProcessingTests
{
    [TestClass]
    public class RNGTests
    {
        [TestMethod]
        public void TestSampleNormDist_OutputMean()
        {
            int N = 512;
            double mean = 0;
            double std = 1;
            double[] samples = new double[N];
            for(int i = 0; i < N; i++)
            {
                samples[i] = RNG.SampleNormalDistribution();
            }

            (double m, double _) = DSP.CalcMeanStd(samples);

            Assert.AreEqual(mean, m, 0.05, "Sampled mean was not close to true value.");
        }

        [TestMethod]
        public void TestSampleNormDist_OutputStd()
        {
            int N = 512;
            double mean = 0;
            double std = 1;
            double[] samples = new double[N];
            for (int i = 0; i < N; i++)
            {
                samples[i] = RNG.SampleNormalDistribution();
            }

            (double _, double s) = DSP.CalcMeanStd(samples);

            Assert.AreEqual(std, s, 0.05, "Sampled std was not close to true value.");
        }
    }
}
