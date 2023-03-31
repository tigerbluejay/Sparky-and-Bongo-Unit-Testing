using Moq;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    
    public class ProductXUnitMoqTests
    {
        [Fact]
        public void Get20PercentDiscount()
        {
            Product product = new Product() { Price = 50 };

            // here we are working with a dependency Customer
            // which is injected via method dependency injection into GetPrice()
            var result = product.GetPrice(new Customer() { IsPlatinum = true });
            // apparently we would need to add an interface (which we would just
            // need for the purposes of mocking - and this is not a recommended practise)

            Assert.Equal(40, result);
        }

        [Fact]
        public void Get20PercentDiscountMoqAbuse()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);
            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(customer.Object);
     
            Assert.Equal(40, result);
        }
    }
}