using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitalSignalProcessing;
using System.Linq;
using System;
using System.Numerics;

namespace DigitalSignalProcessingTests.DSPTests
{
    [TestClass]
    public class Miscellaneous
    {
        [TestMethod]
        public void TestDB_0DB()
        {
            double db = DSP.DB(1);

            Assert.AreEqual(0, db, 0.1);
        }

        [TestMethod]
        public void TestDB_20DB()
        {
            double db = DSP.DB(10);

            Assert.AreEqual(20, db, 0.1);
        }

        [TestMethod]
        public void TestDB_40DB()
        {
            double db = DSP.DB(100);

            Assert.AreEqual(40, db, 0.1);
        }

        [TestMethod]
        public void TestDB_60DB()
        {
            double db = DSP.DB(1000);

            Assert.AreEqual(60, db, 0.1);
        }

        [TestMethod]
        public void TestDB_Neg20DB()
        {
            double db = DSP.DB(0.1);

            Assert.AreEqual(-20, db, 0.1);
        }

        [TestMethod]
        public void TestDB_Neg40DB()
        {
            double db = DSP.DB(0.01);

            Assert.AreEqual(-40, db, 0.1);
        }

        [TestMethod]
        public void TestDB_Neg60DB()
        {
            double db = DSP.DB(0.001);

            Assert.AreEqual(-60, db, 0.1);
        }
    }
}
