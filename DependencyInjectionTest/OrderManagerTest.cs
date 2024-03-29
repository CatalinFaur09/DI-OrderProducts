using System;
using Xunit;
using DependencyInjection;
using Moq;

namespace DependencyInjectionTest
{
    public class OrderManagerTest
    {
        [Fact]
        public void Test1()
        {
            var productStockRepositoryMock = new Mock<IProductStockRepository>();
            productStockRepositoryMock
                .Setup(m => m.IsInStock(It.IsAny<Product>()))
                .Returns(false);

            var paymentProcessorMock = new Mock<IPaymentProcessor>();
            var shippingProcessorMock = new Mock<IShippingProcessor>();


            var orderManager = new OrderManager(productStockRepositoryMock.Object, paymentProcessorMock.Object, shippingProcessorMock.Object);
           
            Assert.ThrowsAny<Exception>(() => orderManager.Submit(Product.Keyboard, "1000100010001000", "1220"));

        }
    }
}
