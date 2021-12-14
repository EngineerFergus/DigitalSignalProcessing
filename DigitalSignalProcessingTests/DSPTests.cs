using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitalSignalProcessingTests
{
    [TestClass]
    public class DSPTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1, "one equals one");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, 2, "one does not equal two");
        }
    }
}
