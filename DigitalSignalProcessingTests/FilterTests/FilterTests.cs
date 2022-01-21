using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.FilterTests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void TestLowPassFilter_KernelLength()
        {
            int M = 51;
            double fc = 0.2;
            LowPassFilter filter = new LowPassFilter(fc, M);
            Assert.AreEqual(M, filter.Kernel.Length);
        }

        [TestMethod]
        public void TestLowPassFilter_EvenKernelLengthThrowsException()
        {
            int M = 64;
            double fc = 0.2;
            Assert.ThrowsException<ArgumentException>(() => new LowPassFilter(fc, M));
        }

        [TestMethod]
        public void TestLowPassFilter_OutOfRangeFrequencyThrowsException()
        {
            int M = 51;
            double fc = 1.2;
            Assert.ThrowsException<ArgumentException>(() => new LowPassFilter(fc, M));
        }

        [TestMethod]
        public void TestLowPassFilter_FrequencyResponseMagnitude()
        {
            int M = 101;
            double fc = 0.25;
            LowPassFilter filter = new LowPassFilter(fc, M);
            double[] freqZ = DSP.Magnitude(filter.FrequencyResponse(128));

            for(int i = 0; i < freqZ.Length / 2; i++)
            {
                double fi = (double)i / 128;
                double idealMag = fi < fc ? 1 : 0;
                if (i == freqZ.Length / 4) { idealMag = 0.5; }
                Assert.AreEqual(idealMag, freqZ[i], 0.5);
            }

        }

        [TestMethod]
        public void TestHighPassFilter_KernelLength()
        {
            int M = 51;
            double fc = 0.2;
            HighPassFilter filter = new HighPassFilter(fc, M);
            Assert.AreEqual(M, filter.Kernel.Length);
        }

        [TestMethod]
        public void TestHighPassFilter_EvenKernelLengthThrowsException()
        {
            int M = 64;
            double fc = 0.2;
            Assert.ThrowsException<ArgumentException>(() => new HighPassFilter(fc, M));
        }

        [TestMethod]
        public void TestHighPassFilter_OutOfRangeFrequencyThrowsException()
        {
            int M = 51;
            double fc = 1.2;
            Assert.ThrowsException<ArgumentException>(() => new HighPassFilter(fc, M));
        }

        [TestMethod]
        public void TestHighPassFilter_FrequencyResponseMagnitude()
        {
            int M = 101;
            double fc = 0.25;
            HighPassFilter filter = new HighPassFilter(fc, M);
            double[] freqZ = DSP.Magnitude(filter.FrequencyResponse(128));

            for (int i = 0; i < freqZ.Length / 2; i++)
            {
                double fi = (double)i / 128;
                double idealMag = fi > fc ? 1 : 0;
                if (i == freqZ.Length / 4) { idealMag = 0.5; }
                Assert.AreEqual(idealMag, freqZ[i], 0.5);
            }

        }

        [TestMethod]
        public void TestBandPassFilter_KernelLength()
        {
            int M = 51;
            double fc = 0.2;
            double fc2 = 0.3;
            BandPassFilter filter = new BandPassFilter(fc, fc2, M);
            Assert.AreEqual(M, filter.Kernel.Length);
        }

        [TestMethod]
        public void TestBandPassFilter_EvenKernelLengthThrowsException()
        {
            int M = 64;
            double fc = 0.2;
            double fc2 = 0.3;
            Assert.ThrowsException<ArgumentException>(() => new BandPassFilter(fc, fc2, M));
        }

        [TestMethod]
        public void TestBandPassFilter_OutOfRangeFrequencyThrowsException()
        {
            int M = 51;
            double fc = 0.2;
            double fc2 = 1.1;
            Assert.ThrowsException<ArgumentException>(() => new BandPassFilter(fc, fc2, M));
        }
    }
}
