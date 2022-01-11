using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.DSPTests
{
    [TestClass]
    public class FourierTransforms
    {
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

            for (int i = 0; i < x.Length; i++)
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
            for (int i = 0; i < 3; i++)
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
            Assert.ThrowsException<ArgumentException>(() => DSP.ZeroPad(x, 3));
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
            Assert.ThrowsException<ArgumentException>(() => DSP.ZeroPad(x, 3));
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

            for (int i = 0; i < x.Length; i++)
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

            for (int i = 1; i < N / 2; i++)
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

            for (int i = 0; i < N; i++)
            {
                Assert.AreEqual(original[i], xOutput[i], 0.01 * original[i]);
            }
        }

        [TestMethod]
        public void TestDFT_ImpulseResponseMagnitude()
        {
            double[] impulse = DSP.Impulse(64);
            Complex[] f = DSP.DFT(impulse);

            for(int i = 0; i < f.Length; i++)
            {
                Assert.AreEqual(1.0, f[i].Magnitude, 0.01);
            }

        }

        [TestMethod]
        public void TestDFT_ImpulseResponsePhase()
        {
            double[] impulse = DSP.Impulse(64);
            Complex[] f = DSP.DFT(impulse);

            for (int i = 0; i < f.Length; i++)
            {
                Assert.AreEqual(0.0, f[i].Phase, 0.01);
            }
        }

        [TestMethod]
        public void TestDFT_ImpulseResponseWithDelayMagnitude()
        {
            double[] impulse = DSP.Impulse(64, 1, 4);
            Complex[] f = DSP.DFT(impulse);

            for (int i = 0; i < f.Length; i++)
            {
                Assert.AreEqual(1.0, f[i].Magnitude, 0.01);
            }

        }

        [TestMethod]
        public void TestFFT_ImpulseResponseMagnitude()
        {
            double[] impulse = DSP.Impulse(64);
            Complex[] f = DSP.FFT(impulse);

            for (int i = 0; i < f.Length; i++)
            {
                Assert.AreEqual(1.0, f[i].Magnitude, 0.01);
            }

        }

        [TestMethod]
        public void TestFFT_ImpulseResponsePhase()
        {
            double[] impulse = DSP.Impulse(64);
            Complex[] f = DSP.FFT(impulse);

            for (int i = 0; i < f.Length; i++)
            {
                Assert.AreEqual(0.0, f[i].Phase, 0.01);
            }
        }

        [TestMethod]
        public void TestFFT_ImpulseResponseWithDelayMagnitude()
        {
            double[] impulse = DSP.Impulse(64, 1, 4);
            Complex[] f = DSP.FFT(impulse);

            for (int i = 0; i < f.Length; i++)
            {
                Assert.AreEqual(1.0, f[i].Magnitude, 0.01);
            }

        }
    }
}
