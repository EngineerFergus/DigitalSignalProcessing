using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests
{
    [TestClass]
    public class DSPTests
    {
        [TestMethod]
        public void TestCalcMeanStd_MeanCalculations()
        {
            double[] data = new double[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(4.667, mean, 0.001);
        }

        [TestMethod]
        public void TestCalcMeanStd_StdCalculations()
        {
            double[] data = new double[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(3.83, std, 0.01);
        }

        [TestMethod]
        public void TestCalcMeanStdInt_MeanCalculations()
        {
            int[] data = new int[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(4.667, mean, 0.001);
        }

        [TestMethod]
        public void TestCalcMeanStdInt_StdCalculations()
        {
            int[] data = new int[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(3.83, std, 0.01);
        }

        [TestMethod]
        public void TestCalcHist_LowValue()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };
            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(-4, lowVal);
        }

        [TestMethod]
        public void TestCalcHist_HighValue()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };

            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(5, highVal);
            }

        [TestMethod]
        public void TestCalcHist_HistogramLength()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };
            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(trueHist.Length, hist.Length);
        }

        [TestMethod]
        public void TestCalcHist_HistogramCount()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(dataOne.Length, hist.Sum());
        }

        [TestMethod]
        public void TestCalcHist_BinCount()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };

            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            for (int i = 0; i < hist.Length; i++)
            {
                Assert.AreEqual(hist[i], trueHist[i]);
            }
        }

        [TestMethod]
        public void TestCalcHistDouble_LowValue()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(0, low, 0.01);
        }

        [TestMethod]
        public void TestCalcHistDouble_HighValue()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(10, high, 0.01);
        }

        [TestMethod]
        public void TestCalcHistDouble_HistogramLength()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(trueHist.Length, hist.Length);
        }

        [TestMethod]
        public void TestCalcHistDouble_HistogramSum()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(data.Length, hist.Sum());
        }

        [TestMethod]
        public void TestCalcHistDouble_BinCount()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);

            for (int i = 0; i < hist.Length; i++)
            {
                Assert.AreEqual(trueHist[i], hist[i]);
            }
        }

        [TestMethod]
        public void TestEvenDecompose_OutputLength()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] evenDecomp = DSP.EvenDecompose(data);
            Assert.AreEqual(data.Length, evenDecomp.Length);
        }

        [TestMethod]
        public void TestEvenDecompose_FirstSample()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] evenDecomp = DSP.EvenDecompose(data);
            int N = data.Length;
            Assert.AreEqual(data[0], evenDecomp[0], 0.01);
        }

        [TestMethod]
        public void TestEvenDecompose_EvenSymmetry()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] evenDecomp = DSP.EvenDecompose(data);
            int N = data.Length;
            for (int i = 1; i < data.Length / 2; i++)
            {
                int j = N - i;
                Assert.AreEqual(evenDecomp[i], evenDecomp[j], 0.01);
            }
        }

        [TestMethod]
        public void TestOddDecompose_OutputLength()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] oddDecomp = DSP.OddDecompose(data);
            int N = data.Length;
            Assert.AreEqual(data.Length, oddDecomp.Length);
        }

        [TestMethod]
        public void TestOddDecompose_FirstSample()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] oddDecomp = DSP.OddDecompose(data);
            int N = data.Length;
            Assert.AreEqual(0, oddDecomp[0], 0.01);
        }

        [TestMethod]
        public void TestOddDecompose_OddSymmetry()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] oddDecomp = DSP.OddDecompose(data);
            int N = data.Length;
            for (int i = 1; i < oddDecomp.Length / 2; i++)
            {
                int j = N - i;
                Assert.AreEqual(-oddDecomp[i], oddDecomp[j]);
            }
        }

        [TestMethod]
        public void TestInterlacedDecompose_xEOutputLength()
        {
            double[] x = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] xE, xO;
            (xE, xO) = DSP.InterlacedDecompose(x);

            Assert.AreEqual(x.Length / 2, xE.Length);
        }

        [TestMethod]
        public void TestInterlacedDecompose_xOOutputLength()
        {
            double[] x = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] xE, xO;
            (xE, xO) = DSP.InterlacedDecompose(x);

            Assert.AreEqual(x.Length / 2, xO.Length);
        }

        [TestMethod]
        public void TestInterlacedDecompose_xEOutputValues()
        {
            double[] x = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] xE;
            (xE, _) = DSP.InterlacedDecompose(x);

            for(int i = 0; i < x.Length / 2; i++)
            {
                Assert.AreEqual(x[2 * i], xE[i]);
            }
        }

        [TestMethod]
        public void TestInterlacedDecompose_xOOutputValues()
        {
            double[] x = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] xO;
            (_, xO) = DSP.InterlacedDecompose(x);

            for (int i = 0; i < x.Length / 2; i++)
            {
                Assert.AreEqual(x[2 * i + 1], xO[i]);
            }
        }

        [TestMethod]
        public void TestInterlacedDecomposeComplex_xEOutputLength()
        {
            Complex[] x = new Complex[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Complex[] xE, xO;
            (xE, xO) = DSP.InterlacedDecompose(x);

            Assert.AreEqual(x.Length / 2, xE.Length);
        }

        [TestMethod]
        public void TestInterlacedDecomposeComplex_xOOutputLength()
        {
            Complex[] x = new Complex[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Complex[] xE, xO;
            (xE, xO) = DSP.InterlacedDecompose(x);

            Assert.AreEqual(x.Length / 2, xO.Length);
        }

        [TestMethod]
        public void TestInterlacedDecomposeComplex_xEOutputValues()
        {
            Complex[] x = new Complex[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Complex[] xE;
            (xE, _) = DSP.InterlacedDecompose(x);

            for (int i = 0; i < x.Length / 2; i++)
            {
                Assert.AreEqual(x[2 * i], xE[i]);
            }
        }

        [TestMethod]
        public void TestInterlacedDecomposeComplex_xOOutputValues()
        {
            Complex[] x = new Complex[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Complex[] xO;
            (_, xO) = DSP.InterlacedDecompose(x);

            for (int i = 0; i < x.Length / 2; i++)
            {
                Assert.AreEqual(x[2 * i + 1], xO[i]);
            }
        }

        [TestMethod]
        public void TestNaiveConv_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestNaiveConv_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 9, 12, 9, 5 };

            for(int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestNaiveConv_EvenXInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestNaiveConv_EvenHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestNaiveConv_EvenXAndHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestNaiveConv_EvenXInput_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 9, 12, 15, 11, 6 };

            for(int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestNaiveConv_EvenHInput_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 10, 14, 12, 9, 5 };

            for(int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestNaiveConv_EvenXAndHInput_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 10, 14, 18, 15, 11, 6 };

            for(int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestOptimConv_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestOptimConv_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 9, 12, 9, 5 };

            for (int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestOptimConv_EvenXInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestOptimConv_EvenHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestOptimConv_EvenXAndHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length);
        }

        [TestMethod]
        public void TestOptimConv_EvenXInput_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 9, 12, 15, 11, 6 };

            for (int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestOptimConv_EvenHInput_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 10, 14, 12, 9, 5 };

            for (int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestOptimConv_EvenXAndHInput_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            double[] yTrue = new double[] { 1, 3, 6, 10, 14, 18, 15, 11, 6 };

            for (int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

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

            for(int i = 0; i < ham.Length; i++)
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

            foreach(double r in rectangleWindow)
            {
                if(maxVal < r)
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

            for(int i = 0; i < M; i++)
            {
                if(rectangleWindow[i] != 0.0)
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
                if(rectangleWindow[i] != 0) { nonZeroSamples++; }
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

            foreach(double sample in impulse)
            {
                if(sample > max)
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
            
            for(int i = 0; i < impulse.Length; i++)
            {
                if(impulse[i] != 0)
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

            for(int i = 0; i < step.Length; i++)
            {
                if(step[i] > maxVal)
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
                if(step[i] == 0) { zeroSamples++; }
            }

            Assert.AreEqual(delay, zeroSamples);
        }

        [TestMethod]
        public void TestAverageFilter_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
            int boxSize = 3;
            double[] y = DSP.AverageFilter(x, boxSize);
            Assert.AreEqual(x.Length, y.Length);
        }

        [TestMethod]
        public void TestAverageFilter_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 10, 10, 4, 3, 2, 1 };
            int boxSize = 3;
            double[] y = DSP.AverageFilter(x, boxSize);
            double[] yTrue = new double[] { 1, 2, 3, 5.67, 8, 8, 5.67, 3, 2, 1 };

            for(int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }

        [TestMethod]
        public void TestAverageFilter_LargeBoxSize()
        {
            double[] x = new double[] { 1, 2, 3, 4, 10, 10, 4, 3, 2, 1 };
            int boxSize = 9;
            double[] y = DSP.AverageFilter(x, boxSize);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_ZeroInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(0);
            Assert.AreEqual(1, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_OneInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(1);
            Assert.AreEqual(1, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_FourInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(4);
            Assert.AreEqual(4, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_ThirtyOneInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(31);
            Assert.AreEqual(32, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_TwentyInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(20);
            Assert.AreEqual(32, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_FortyInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(40);
            Assert.AreEqual(64, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_ThousandInput()
        {
            int pow = DSP.NextLargestPowerOfTwo(1000);
            Assert.AreEqual(1024, pow);
        }

        [TestMethod]
        public void TestNextLargestPowerOfTwo_LargestInput()
        {
            Assert.ThrowsException<OverflowException>(() => DSP.NextLargestPowerOfTwo(int.MaxValue));
        }

        [TestMethod]
        public void TestMagnitude_OutputLength()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            double[] mag = DSP.Magnitude(x);
            Assert.AreEqual(x.Length, mag.Length);
        }

        [TestMethod]
        public void TestMagnitude_OutputValues()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            double[] mag = DSP.Magnitude(x);

            for(int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i].Magnitude, mag[i], 0.01);
            }
        }

        [TestMethod]
        public void TestPhase_OutputLength()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            double[] mag = DSP.Phase(x);
            Assert.AreEqual(x.Length, mag.Length);
        }

        [TestMethod]
        public void TestPhase_OutputValues()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            double[] mag = DSP.Phase(x);

            for (int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i].Phase, mag[i], 0.01);
            }
        }

        [TestMethod]
        public void TestReal_OutputLength()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            double[] mag = DSP.Real(x);
            Assert.AreEqual(x.Length, mag.Length);
        }

        [TestMethod]
        public void TestReal_OutputValues()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            double[] mag = DSP.Real(x);

            for (int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i].Real, mag[i], 0.01);
            }
        }

        [TestMethod]
        public void TestSwapComplex()
        {
            Complex x = new Complex(1, 2);
            Complex swapped = DSP.SwapComplex(x);
            Assert.AreEqual(x.Real, swapped.Imaginary);
            Assert.AreEqual(x.Imaginary, swapped.Real);
        }

        [TestMethod]
        public void TestSwapComplexArray()
        {
            Complex[] x = new Complex[] { new Complex(1, 2), new Complex(2, 3), new Complex(3, 4) };
            Complex[] y = new Complex[3];
            Array.Copy(x, y, 3);
            DSP.SwapComplex(ref y);
            for(int i = 0; i < 3; i++)
            {
                Assert.AreEqual(x[i].Real, y[i].Imaginary);
                Assert.AreEqual(x[i].Imaginary, y[i].Real);
            }
        }

        [TestMethod]
        public void TestZeroPad_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] padded = DSP.ZeroPad(x, 10);
            Assert.AreEqual(10, padded.Length);
        }

        [TestMethod]
        public void TestZeroPad_ImproperInput()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            Assert.ThrowsException<Exception>(() => DSP.ZeroPad(x, 3));
        }

        [TestMethod]
        public void TestZeroPadComplex_OutputLength()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            Complex[] padded = DSP.ZeroPad(x, 10);
            Assert.AreEqual(10, padded.Length);
        }

        [TestMethod]
        public void TestZeroPadComplex_ImproperInput()
        {
            Complex[] x = new Complex[] { 1, 2, 3, 4, 5 };
            Assert.ThrowsException<Exception>(() => DSP.ZeroPad(x, 3));
        }

        [TestMethod]
        public void TestConvertToComplex_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            Complex[] xComp = DSP.ConvertToComplex(x);
            Assert.AreEqual(x.Length, xComp.Length);
        }

        [TestMethod]
        public void TestDFT_OutputLength()
        {
            double[] x = DSP.Hamming(128);
            Complex[] f = DSP.DFT(x);
            Assert.AreEqual(x.Length, f.Length);
        }

        [TestMethod]
        public void TestIDFT_OutputLength()
        {
            double[] x = DSP.Hamming(128);
            Complex[] f = DSP.DFT(x);
            double[] xPrime = DSP.IDFT(f);
            Assert.AreEqual(x.Length, xPrime.Length);
        }

        [TestMethod]
        public void TestDFT_OutputSymmetry()
        {
            double[] x = DSP.Hamming(128);
            Complex[] f = DSP.DFT(x);

            for (int i = 1; i < f.Length / 2; i++)
            {
                int j = f.Length - i;
                Assert.AreEqual(f[i].Magnitude, f[j].Magnitude, f[i].Magnitude * 0.01);
            }
        }

        [TestMethod]
        public void TestDFTAndIDFT_OutputEquivalence()
        {
            double[] x = DSP.Hamming(128);
            Complex[] f = DSP.DFT(x);
            double[] xP = DSP.IDFT(f);

            for(int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i], xP[i], x[i] * 0.01);
            }

        }

        [TestMethod]
        public void TestFFT_OutputLength()
        {
            double[] x = DSP.Hamming(120);
            int nextPow = DSP.NextLargestPowerOfTwo(120);
            Complex[] xC = DSP.ConvertToComplex(x);
            Complex[] f = DSP.FFT(xC);
            Assert.AreEqual(nextPow, f.Length);
        }

        [TestMethod]
        public void TestIFFT_OutputLength()
        {
            Complex[] x = DSP.ConvertToComplex(DSP.Hamming(128));
            Complex[] f = DSP.FFT(x);
            Complex[] xPrime = DSP.IFFT(f);
            Assert.AreEqual(128, xPrime.Length);
        }

        [TestMethod]
        public void TestFFT_OutputSymmetry()
        {
            int N = 128;
            Complex[] x = DSP.ConvertToComplex(DSP.Hamming(N));
            Complex[] f = DSP.FFT(x);

            for(int i = 1; i < N / 2; i++)
            {
                int j = N - i;
                Assert.AreEqual(f[i].Magnitude, f[j].Magnitude, 0.01 * f[i].Magnitude);
            }
        }

        [TestMethod]
        public void TestFFTAndIFFT_OutputEquivalence()
        {
            int N = 128;
            double[] original = DSP.Hamming(N);
            Complex[] x = DSP.ConvertToComplex(original);
            Complex[] f = DSP.FFT(x);
            Complex[] xPrime = DSP.IFFT(f);
            double[] xOutput = DSP.Real(xPrime);

            for(int i = 0; i < N; i++)
            {
                Assert.AreEqual(original[i], xOutput[i], 0.01 * original[i]);
            }
        }
    }
}
