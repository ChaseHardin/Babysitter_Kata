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

            var actual = GenerateReceiptService.Calculate();
            
            Assert.AreEqual(24, actual);
        }
    }
}