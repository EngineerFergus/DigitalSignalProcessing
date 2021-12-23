using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;

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
            Assert.AreEqual(4.667, mean, 0.001, "Mean was not within tolerance.");
        }

        [TestMethod]
        public void TestCalcMeanStd_StdCalculations()
        {
            double[] data = new double[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(3.83, std, 0.01, "Standard deviation was not within tolerance.");
        }

        [TestMethod]
        public void TestCalcMeanStdInt_MeanCalculations()
        {
            int[] data = new int[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(4.667, mean, 0.001, "Mean was not within tolerance.");
        }

        [TestMethod]
        public void TestCalcMeanStdInt_StdCalculations()
        {
            int[] data = new int[] { 1, 2, 3, 3, 9, 10 };
            (double mean, double std) = DSP.CalcMeanStd(data);
            Assert.AreEqual(3.83, std, 0.01, "Standard deviation was not within tolerance.");
        }

        [TestMethod]
        public void TestCalcHist_LowValue()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };
            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(-4, lowVal, "Low values of histogram did not match.");
        }

        [TestMethod]
        public void TestCalcHist_HighValue()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };

            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(5, highVal, "High values of histogram did not match.");
            }

        [TestMethod]
        public void TestCalcHist_HistogramLength()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };
            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(trueHist.Length, hist.Length, "Histogram lengths were not equal.");
        }

        [TestMethod]
        public void TestCalcHist_HistogramCount()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            Assert.AreEqual(dataOne.Length, hist.Sum(), "Histogram sum did not equal total length of data.");
        }

        [TestMethod]
        public void TestCalcHist_BinCount()
        {
            int[] dataOne = new int[] { -4, -4, -3, -1, -1, -1, 0, 0, 0, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
            int[] trueHist = new int[] { 2, 1, 0, 3, 3, 1, 2, 3, 4, 5 };

            (int[] hist, int lowVal, int highVal) = DSP.CalcHist(dataOne);
            for (int i = 0; i < hist.Length; i++)
            {
                Assert.AreEqual(hist[i], trueHist[i], "Histogram bin count did not match.");
            }
        }

        [TestMethod]
        public void TestCalcHistDouble_LowValue()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(0, low, 0.01, "Low values did not match");
        }

        [TestMethod]
        public void TestCalcHistDouble_HighValue()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(10, high, 0.01, "High values did not match");
        }

        [TestMethod]
        public void TestCalcHistDouble_HistogramLength()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(trueHist.Length, hist.Length, "Histogram lengths did not match.");
        }

        [TestMethod]
        public void TestCalcHistDouble_HistogramSum()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);
            Assert.AreEqual(data.Length, hist.Sum(), "Total count within histogram did not match ");
        }

        [TestMethod]
        public void TestCalcHistDouble_BinCount()
        {
            double[] data = new double[] { 0, 0.1, 0.1, 1.1, 1.1, 1.1, 2.1, 2.1, 2.1, 3.1, 3.1, 3.1, 4.1, 4.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10 };
            int[] trueHist = new int[] { 3, 3, 3, 3, 3, 1, 1, 1, 1, 2 };
            (int[] hist, double low, double high) = DSP.CalcHist(data, 10);

            for (int i = 0; i < hist.Length; i++)
            {
                Assert.AreEqual(trueHist[i], hist[i], $"Histogram bin {i + 1} count did not match");
            }
        }

        [TestMethod]
        public void TestEvenDecompose_OutputLength()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] evenDecomp = DSP.EvenDecompose(data);
            Assert.AreEqual(data.Length, evenDecomp.Length, "Length of even decomposition did not equal original signal length.");
        }

        [TestMethod]
        public void TestEvenDecompose_FirstSample()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] evenDecomp = DSP.EvenDecompose(data);
            int N = data.Length;
            Assert.AreEqual(data[0], evenDecomp[0], 0.01, "First sample in even decomposition did not equal first sample of data.");
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
                Assert.AreEqual(evenDecomp[i], evenDecomp[j], 0.01, $"Even decomposition signal not even symmetric at point {i} and {j}.");
            }
        }

        [TestMethod]
        public void TestOddDecompose_OutputLength()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] oddDecomp = DSP.OddDecompose(data);
            int N = data.Length;
            Assert.AreEqual(data.Length, oddDecomp.Length, "Length of odd decomposition did not equal original signal length.");
        }

        [TestMethod]
        public void TestOddDecompose_FirstSample()
        {
            double[] data = new double[] { 1, 2, 3, 4, 3, 7, 1, 2, 8, 10 };
            double[] oddDecomp = DSP.OddDecompose(data);
            int N = data.Length;
            Assert.AreEqual(0, oddDecomp[0], 0.01, "First sample in odd decomposition did not equal to zero.");
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
                Assert.AreEqual(-oddDecomp[i], oddDecomp[j], $"Odd decomposition signal not odd symmetric at point {i} and {j}.");
            }
        }

        [TestMethod]
        public void TestNaiveConv_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output of NaiveConv length was not correct.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Convolution output at {i} was not correct.");
            }
        }

        [TestMethod]
        public void TestNaiveConv_EvenXInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output from even x input of naive conolution did not have correct length.");
        }

        [TestMethod]
        public void TestNaiveConv_EvenHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output from even x input of naive conolution did not have correct length.");
        }

        [TestMethod]
        public void TestNaiveConv_EvenXAndHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.NaiveConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output from even x input of naive conolution did not have correct length.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Incorrect value at location {i}.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Incorrect value at location {i}.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Incorrect value at location {i}.");
            }
        }

        [TestMethod]
        public void TestOptimConv_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output of NaiveConv length was not correct.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Convolution output at {i} was not correct.");
            }
        }


        [TestMethod]
        public void TestOptimConv_EvenXInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output from even x input of naive conolution did not have correct length.");
        }

        [TestMethod]
        public void TestOptimConv_EvenHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output from even x input of naive conolution did not have correct length.");
        }

        [TestMethod]
        public void TestOptimConv_EvenXAndHInput_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1, 1 };
            double[] y = DSP.OptimConv(x, h);
            int lTrue = x.Length + h.Length - 1;
            Assert.AreEqual(lTrue, y.Length, "Output from even x input of naive conolution did not have correct length.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Incorrect value at location {i}.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Incorrect value at location {i}.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Incorrect value at location {i}.");
            }
        }

        [TestMethod]
        public void TestHamming_OutputLength()
        {
            int M = 32;
            double[] ham = DSP.Hamming(M);
            Assert.AreEqual(M, ham.Length, "Hamming window sequence length was incorrect.");
        }

        [TestMethod]
        public void TestHamming_OutputValues()
        {
            int M = 8;
            double[] ham = DSP.Hamming(M);
            double[] trueHam = new double[] { 0.0800, 0.2532, 0.6424, 0.9544, 0.9544, 0.6424, 0.2532, 0.0800 };

            for(int i = 0; i < ham.Length; i++)
            {
                Assert.AreEqual(trueHam[i], ham[i], 0.0001, $"Hamming sequence incorrect at location {i}.");
            }
        }

        [TestMethod]
        public void TestBlackman_OutputLength()
        {
            int M = 32;
            double[] blackman = DSP.Blackman(M);
            Assert.AreEqual(M, blackman.Length, "Blackman window sequence length was incorrect.");
        }

        [TestMethod]
        public void TestBlackman_OutputValues()
        {
            int M = 8;
            double[] blackman = DSP.Blackman(M);
            double[] trueBlackman = new double[] { 0, 0.0905, 0.4592, 0.9204, 0.9204, 0.4592, 0.0905, 0 };

            for (int i = 0; i < blackman.Length; i++)
            {
                Assert.AreEqual(trueBlackman[i], blackman[i], 0.0001, $"Blackman sequence incorrect at location {i}.");
            }
        }

        [TestMethod]
        public void TestRectangle_OutputLength()
        {
            int M = 32;
            double[] rectangleWindow = DSP.Rectangle(M, 10);
            Assert.AreEqual(M, rectangleWindow.Length, "Rectangle window sequence length was incorrect.");
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

            Assert.AreEqual(magnitude, maxVal, 0.01, "Magnitude of rectangle window was incorrect.");
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

            Assert.AreEqual(delay, delaySample, "Delay sample was not correct in Rectangle sequence.");
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

            Assert.AreEqual(L, nonZeroSamples, $"Rectangle window size was incorrect.");
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

            Assert.AreEqual(L, nonZeroSamples, $"Rectangle window size was incorrect.");
        }

        [TestMethod]
        public void TestImpulse_OutputLength()
        {
            int M = 32;
            double mag = 1;
            int delay = 0;
            double[] impulse = DSP.Impulse(M, mag, delay);
            Assert.AreEqual(M, impulse.Length, "Impulse length was not correct.");
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

            Assert.AreEqual(mag, max, 0.01, "Impulse magnitude was not correct.");
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

            Assert.AreEqual(delay, sampleIndex, "Impulse delay was not correct.");
        }

        [TestMethod]
        public void TestStep_OutputLength()
        {
            int M = 32;
            double[] step = DSP.Step(M);
            Assert.AreEqual(M, step.Length, "Step sequence output length was incorrect.");
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

            Assert.AreEqual(magnitude, maxVal, 0.01, "Step sequence magnitude was incorrect.");
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

            Assert.AreEqual(delay, zeroSamples, "Step sequence delay was incorrect.");
        }

        [TestMethod]
        public void TestAverageFilter_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
            int boxSize = 3;
            double[] y = DSP.AverageFilter(x, boxSize);
            Assert.AreEqual(x.Length, y.Length, "Average filter output length was incorrect.");
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
                Assert.AreEqual(yTrue[i], y[i], 0.01, $"Average filter output incorrect at location {i}.");
            }
        }

        [TestMethod]
        public void TestAverageFilter_LargeBoxSize()
        {
            double[] x = new double[] { 1, 2, 3, 4, 10, 10, 4, 3, 2, 1 };
            int boxSize = 9;
            double[] y = DSP.AverageFilter(x, boxSize);
        }
    }
}
