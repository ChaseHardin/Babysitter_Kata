using System;
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
        public void Calculate_sitter_works_one_hour__returns_total()
        {
            var workedOneHour = _generateReceiptService.Calculate(
                GenerateTimeStamp(),
                GenerateTimeStamp(18)
            );

            Assert.AreEqual(12, workedOneHour);
        }

        [TestMethod]
        public void Calculate_sitter_works_two_hours__returns_total()
        {
            var workedTwoHours = _generateReceiptService.Calculate(
                GenerateTimeStamp(),
                GenerateTimeStamp(19)
            );

            Assert.AreEqual(24, workedTwoHours);
        }

        [TestMethod]
        public void Calculate_sitter_works_three_hours__returns_total()
        {
            var workedThreeHours = _generateReceiptService.Calculate(
                GenerateTimeStamp(),
                GenerateTimeStamp(20)
            );

            Assert.AreEqual(36, workedThreeHours);
        }

        private static DateTime GenerateTimeStamp(int hour = 17, int minute = 00, int seconds = 0)
        {
            var time = DateTime.Now;
            return new DateTime(time.Year, time.Month, time.Day, hour, minute, seconds);
        }
    }
}