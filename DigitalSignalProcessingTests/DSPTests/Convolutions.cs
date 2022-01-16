using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.DSPTests
{
    [TestClass]
    public class Convolutions
    {
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

            for (int i = 0; i < y.Length; i++)
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

            for (int i = 0; i < y.Length; i++)
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

            for (int i = 0; i < y.Length; i++)
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

            for (int i = 0; i < y.Length; i++)
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

            for (int i = 0; i < y.Length; i++)
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
        public void TestTruncConv_OutputLength()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] h = new double[] { 1, 2, 3 };
            double[] y = DSP.TruncConv(x, h);
            Assert.AreEqual(x.Length, y.Length);
        }

        [TestMethod]
        public void TestTruncConv_OutputLengthReversedInputs()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] h = new double[] { 1, 2, 3 };
            double[] y = DSP.TruncConv(h, x);
            Assert.AreEqual(x.Length, y.Length);
        }

        [TestMethod]
        public void TestTruncConv_OutputValues()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] h = new double[] { 1, 1, 1 };
            double[] y = DSP.TruncConv(x, h);
            double[] yTrue = new double[] { 3, 6, 9, 12, 15, 11 };

            for (int i = 0; i < y.Length; i++)
            {
                Assert.AreEqual(yTrue[i], y[i], 0.01);
            }
        }
    }
}
