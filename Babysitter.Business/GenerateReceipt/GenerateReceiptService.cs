namespace Babysitter.Business.GenerateReceipt
{
    public class GenerateReceiptService
    {
        public int Calculate(int hoursWorked)
        {
            return hoursWorked * 12;
        }
    }
}