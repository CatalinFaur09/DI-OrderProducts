using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuild().Build();


        static void Main(string[] args)
        {
            var product = string.Empty;
            var productStockRepository = new ProductStockRepository();
            var orderManager = Container.GetService<IOrderManager>();

            while(product != "Empty")
            {
                Console.WriteLine(@"Please enter your order list
        Keyboard = 0,
        Mouse = 1,
        Mic = 2,
        Speaker = 3");

                product = Console.ReadLine();

                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a payment method: xxxxxxxxxxxxxx;MMYY");
                        var paymentMethod = Console.ReadLine();

                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)

                            throw new Exception("Invalid payment Method");

                        orderManager.Submit(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has been shipped ");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }
                    

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
