using System;
using Babysitter.Business.GenerateReceipt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Babysitter.Business.Tests.GenerateReceipt
{
    [TestClass]
    public class GenerateReceiptTests
    {
        private GenerateReceiptService _generateReceiptService;
        private const int HourlyRate = 12;
        private const int HourlySleepingRate = 8;

        [TestInitialize]
        public void Setup()
        {
            _generateReceiptService = new GenerateReceiptService(HourlyRate, HourlySleepingRate);
        }

        [TestMethod]
        public void Calculate_sitter_works_one_hour__returns_total()
        {
            var startTime = GenerateTimeStamp();
            var endTime = GenerateTimeStamp(18);
            var bedTime = GenerateTimeStamp(21);
            
            var workedOneHour = _generateReceiptService.Calculate(startTime, endTime, bedTime);

            Assert.AreEqual(12, workedOneHour);
        }

        [TestMethod]
        public void Calculate_sitter_works_two_hours__returns_total()
        {
            var startTime = GenerateTimeStamp();
            var endTime = GenerateTimeStamp(19);
            var bedTime = GenerateTimeStamp(21);
            
            var workedTwoHours = _generateReceiptService.Calculate(startTime, endTime, bedTime);

            Assert.AreEqual(24, workedTwoHours);
        }

        [TestMethod]
        public void Calculate_sitter_works_three_hours__returns_total()
        {
            var startTime = GenerateTimeStamp();
            var endTime = GenerateTimeStamp(20);
            var bedTime = GenerateTimeStamp(21);
            
            var workedThreeHours = _generateReceiptService.Calculate(startTime, endTime, bedTime);

            Assert.AreEqual(36, workedThreeHours);
        }

        [TestMethod]
        public void Calculate__sitter_works_two_hours__children_sleep_for_one_returns_total()
        {
            var startTime = GenerateTimeStamp(19);
            var endTime = GenerateTimeStamp(21);
            var bedTime = GenerateTimeStamp(20);
            
            var workedTwoHours = _generateReceiptService.Calculate(startTime, endTime, bedTime);

            Assert.AreEqual(HourlyRate + HourlySleepingRate, workedTwoHours);
        }

        private static DateTime GenerateTimeStamp(int hour = 17, int minute = 00, int seconds = 0)
        {
            var time = DateTime.Now;
            return new DateTime(time.Year, time.Month, time.Day, hour, minute, seconds);
        }
    }
}