using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class ProductNUnitMoqTests
    {
        [Test]
        public void Get20PercentDiscount()
        {
            Product product = new Product() { Price = 50 };

            // here we are working with a dependency Customer
            // which is injected via method dependency injection into GetPrice()
            var result = product.GetPrice(new Customer() { IsPlatinum = true });
            // apparently we would need to add an interface (which we would just
            // need for the purposes of mocking - and this is not a recommended practise)

            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void Get20PercentDiscountMoqAbuse()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);
            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(customer.Object);
     
            Assert.That(result, Is.EqualTo(40));
        }
    }
}

// Next video is 48 Setup LogBook Withdrawal