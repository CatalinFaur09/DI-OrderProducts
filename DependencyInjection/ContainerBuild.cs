using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class ContainerBuild
    {
        //ASP.NET CORE DI
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IOrderManager, OrderManager>();
            container.AddSingleton<IPaymentProcessor, PaymentProcessor>();
            container.AddSingleton<IShippingProcessor, ShippingProcessor>();
            container.AddSingleton<IProductStockRepository, ProductStockRepository>();

            return container.BuildServiceProvider();
        }


    }
}
