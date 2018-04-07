using Babysitter.Business.GenerateReceipt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Babysitter.Business.Tests.GenerateReceipt
{
    [TestClass]
    public class GenerateReceiptTests
    {
        private GenerateReceiptService _generateReceiptService;
        
        [TestInitialize]
        public void Setup()
        {
            _generateReceiptService = new GenerateReceiptService();
        }

        [TestMethod]
        public void Calculate_takes_hours_worked__returns_total()
        {
            Assert.AreEqual(12, _generateReceiptService.Calculate(1));
            Assert.AreEqual(24, _generateReceiptService.Calculate(2));
            Assert.AreEqual(36, _generateReceiptService.Calculate(3));
            Assert.AreEqual(48, _generateReceiptService.Calculate(4));
            Assert.AreEqual(60, _generateReceiptService.Calculate(5));
        }
    }
}