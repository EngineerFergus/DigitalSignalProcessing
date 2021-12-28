using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.DSPTests
{
    [TestClass]
    public class Decompositions
    {
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

            for (int i = 0; i < x.Length / 2; i++)
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
    }
}
