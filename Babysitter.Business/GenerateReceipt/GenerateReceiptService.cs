using System;

namespace Babysitter.Business.GenerateReceipt
{
    public class GenerateReceiptService
    {
        public int Calculate(DateTime startTime, DateTime endTime)
        {
            var hoursWorked = endTime.Subtract(startTime);
            return (int) (hoursWorked.TotalHours * 12);
        }
    }
}