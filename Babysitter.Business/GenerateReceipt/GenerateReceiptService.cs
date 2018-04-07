using System;

namespace Babysitter.Business.GenerateReceipt
{
    public class GenerateReceiptService
    {
        public int Calculate(DateTime startTime, DateTime endTime)
        {
            return (int) (HoursWorked(startTime, endTime).TotalHours * 12);
        }

        private static TimeSpan HoursWorked(DateTime startTime, DateTime endTime)
        {
            return endTime.Subtract(startTime);
        }
    }
}