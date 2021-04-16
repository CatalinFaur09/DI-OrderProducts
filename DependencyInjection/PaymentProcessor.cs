using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IPaymentProcessor
    {
        void ChargeCreditCard(string creditCarnNumber, string expireData);
    }
    class PaymentProcessor : IPaymentProcessor
    {
        public void ChargeCreditCard(string creditCarnNumber, string expireData)
        {
            if(string.IsNullOrEmpty(creditCarnNumber))
            {
                throw new ArgumentException($"{creditCarnNumber} is not valid");
            }

            if(string.IsNullOrEmpty(expireData))
            {
                throw new ArgumentException($"{expireData} is expired");
            }

            Console.WriteLine("Call to credit card API");
        }
    }
}
