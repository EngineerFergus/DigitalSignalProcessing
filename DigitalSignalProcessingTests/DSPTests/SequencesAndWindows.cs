using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.DSPTests
{
    [TestClass]
    public class SequencesAndWindows
    {
        [TestMethod]
        public void TestHamming_OutputLength()
        {
            int M = 32;
            double[] ham = DSP.Hamming(M);
            Assert.AreEqual(M, ham.Length);
        }

        [TestMethod]
        public void TestHamming_OutputValues()
        {
            int M = 8;
            double[] ham = DSP.Hamming(M);
            double[] trueHam = new double[] { 0.0800, 0.2532, 0.6424, 0.9544, 0.9544, 0.6424, 0.2532, 0.0800 };

            for (int i = 0; i < ham.Length; i++)
            {
                Assert.AreEqual(trueHam[i], ham[i], 0.0001);
            }
        }

        [TestMethod]
        public void TestBlackman_OutputLength()
        {
            int M = 32;
            double[] blackman = DSP.Blackman(M);
            Assert.AreEqual(M, blackman.Length);
        }

        [TestMethod]
        public void TestBlackman_OutputValues()
        {
            int M = 8;
            double[] blackman = DSP.Blackman(M);
            double[] trueBlackman = new double[] { 0, 0.0905, 0.4592, 0.9204, 0.9204, 0.4592, 0.0905, 0 };

            for (int i = 0; i < blackman.Length; i++)
            {
                Assert.AreEqual(trueBlackman[i], blackman[i], 0.0001);
            }
        }

        [TestMethod]
        public void TestRectangle_OutputLength()
        {
            int M = 32;
            double[] rectangleWindow = DSP.Rectangle(M, 10);
            Assert.AreEqual(M, rectangleWindow.Length);
        }

        [TestMethod]
        public void TestRectangle_Magnitude()
        {
            int M = 32;
            int L = 8;
            double magnitude = 3.0;
            double[] rectangleWindow = DSP.Rectangle(M, L, magnitude);
            double maxVal = double.MinValue;

            foreach (double r in rectangleWindow)
            {
                if (maxVal < r)
                {
                    maxVal = r;
                }
            }

            Assert.AreEqual(magnitude, maxVal, 0.01);
        }

        [TestMethod]
        public void TestRectangle_Delay()
        {
            int M = 32;
            int L = 8;
            double magnitude = 3.0;
            int delay = 8;
            double[] rectangleWindow = DSP.Rectangle(M, L, magnitude, delay);
            int delaySample = -1;

            for (int i = 0; i < M; i++)
            {
                if (rectangleWindow[i] != 0.0)
                {
                    delaySample = i;
                    break;
                }
            }

            Assert.AreEqual(delay, delaySample);
        }

        [TestMethod]
        public void TestRectangle_WindowSize()
        {
            int M = 32;
            int L = 8;
            double magnitude = 1;
            int delay = 0;
            double[] rectangleWindow = DSP.Rectangle(M, L, magnitude, delay);
            int nonZeroSamples = 0;

            for (int i = 0; i < M; i++)
            {
                if (rectangleWindow[i] != 0) { nonZeroSamples++; }
            }

            Assert.AreEqual(L, nonZeroSamples);
        }

        [TestMethod]
        public void TestRectangle_WindowSizeWithDelay()
        {
            int M = 32;
            int L = 8;
            double magnitude = 1;
            int delay = 8;
            double[] rectangleWindow = DSP.Rectangle(M, L, magnitude, delay);
            int nonZeroSamples = 0;

            for (int i = 0; i < M; i++)
            {
                if (rectangleWindow[i] != 0) { nonZeroSamples++; }
            }

            Assert.AreEqual(L, nonZeroSamples);
        }

        [TestMethod]
        public void TestImpulse_OutputLength()
        {
            int M = 32;
            double mag = 1;
            int delay = 0;
            double[] impulse = DSP.Impulse(M, mag, delay);
            Assert.AreEqual(M, impulse.Length);
        }

        [TestMethod]
        public void TestImpulse_OutputMagnitude()
        {
            int M = 32;
            double mag = 2;
            int delay = 0;
            double[] impulse = DSP.Impulse(M, mag, delay);
            double max = double.MinValue;

            foreach (double sample in impulse)
            {
                if (sample > max)
                {
                    max = sample;
                }
            }

            Assert.AreEqual(mag, max, 0.01);
        }

        [TestMethod]
        public void TestImpulse_OutputDelay()
        {
            int M = 32;
            double mag = 2;
            int delay = 0;
            double[] impulse = DSP.Impulse(M, mag, delay);
            int sampleIndex = -1;

            for (int i = 0; i < impulse.Length; i++)
            {
                if (impulse[i] != 0)
                {
                    sampleIndex = i;
                    break;
                }
            }

            Assert.AreEqual(delay, sampleIndex);
        }

        [TestMethod]
        public void TestStep_OutputLength()
        {
            int M = 32;
            double[] step = DSP.Step(M);
            Assert.AreEqual(M, step.Length);
        }

        [TestMethod]
        public void TestStep_OutputMagnitude()
        {
            int M = 32;
            double magnitude = 2;
            int delay = 0;
            double[] step = DSP.Step(M, magnitude, delay);
            double maxVal = double.MinValue;

            for (int i = 0; i < step.Length; i++)
            {
                if (step[i] > maxVal)
                {
                    maxVal = step[i];
                }
            }

            Assert.AreEqual(magnitude, maxVal, 0.01);
        }

        [TestMethod]
        public void TestStep_OutputDelay()
        {
            int M = 32;
            double magnitude = 2;
            int delay = 8;
            double[] step = DSP.Step(M, magnitude, delay);
            int zeroSamples = 0;

            for (int i = 0; i < step.Length; i++)
            {
                if (step[i] == 0) { zeroSamples++; }
            }

            Assert.AreEqual(delay, zeroSamples);
        }
    }
}
