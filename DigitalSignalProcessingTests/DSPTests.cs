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

    }
}
