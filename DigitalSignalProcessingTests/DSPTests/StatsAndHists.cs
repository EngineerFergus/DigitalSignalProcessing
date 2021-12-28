using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.DSPTests
{
    [TestClass]
    public class StatsAndHists
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
    }
}
