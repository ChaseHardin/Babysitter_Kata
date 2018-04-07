using System;

namespace Babysitter.Business.GenerateReceipt
{
    public class GenerateReceiptService
    {
        private readonly int _hourlyRate;
        private readonly int _hourlySleepingRate;

        public GenerateReceiptService(int hourlyRate, int hourlySleepingRate)
        {
            _hourlyRate = hourlyRate;
            _hourlySleepingRate = hourlySleepingRate;
        }

        public int Calculate(DateTime startTime, DateTime endTime, DateTime bedTime)
        {
            var totalHours = HoursWorked(startTime, endTime);
            var totalBedtimeHours = HoursWorked(bedTime, endTime);

            return HasSleepingHours(totalBedtimeHours)
                ? totalHours * _hourlyRate
                : RateWithBedtime(totalBedtimeHours, totalHours);
        }

        private int RateWithBedtime(int bedtimeHours, int totalSittingHours)
        {
            var bedTimeRate = bedtimeHours * _hourlySleepingRate;
            var hourlyRate = (totalSittingHours - bedtimeHours) * _hourlyRate;
            
            return bedTimeRate + hourlyRate;
        }

        private static bool HasSleepingHours(int hours)
        {
            return hours < 0;
        }
        
        private static int HoursWorked(DateTime startTime, DateTime endTime)
        {
            return (int) endTime.Subtract(startTime).TotalHours;
        }
    }
}