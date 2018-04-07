using Babysitter.Business.GenerateReceipt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Babysitter.Business.Tests.GenerateReceipt
{
    [TestClass]
    public class GenerateReceiptTests
    {
        [TestMethod]
        public void Calculate__works_for_one_hour__returns_total()
        {
            var generateReceiptService = new GenerateReceiptService();

            var actual = generateReceiptService.Calculate(1);
            
            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void Calculate__works_for_two_hours__returns_total()
        {
            var generateReceiptService = new GenerateReceiptService();

            var actual = generateReceiptService.Calculate(2);
            
            Assert.AreEqual(24, actual);
        }
    }
}