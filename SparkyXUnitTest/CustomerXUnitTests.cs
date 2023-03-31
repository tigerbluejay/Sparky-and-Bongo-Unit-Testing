using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void GetGreetingandCombinedNames()
        {
            // replaced by the setup method
            // var customer = new Customer();

            customer.GreetandCombineNames("Ben", "Spark");

            
            Assert.Equal("Hello, Ben Spark", customer.GreetMessage);

            //other functionalities
            Assert.Contains(",", customer.GreetMessage);
            Assert.StartsWith("Hello", customer.GreetMessage);
            Assert.EndsWith("Spark", customer.GreetMessage);
            Assert.Contains("ben", customer.GreetMessage.ToLower());
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        }

        [Fact]
        public void GetNullforGreetMessageProp()
        {
            // replaced by the setup method
            // var customer = new Customer();

            Assert.Null(customer.GreetMessage);
        }
        [Fact]
        public void GetDiscountinRange()
        {
            int result = customer.Discount;

            // assert a value within a range
            Assert.InRange(result, 10, 25);
        }

        // Multiple assertions allow you to have a list of asserts within one test method
        // and check all of the asserts, instead of having the check stopped
        // on the remaining asserts if one prior fails first
        [Fact]
        public void GetGreetingandCombinedNames2()
        {
            // replaced by the setup method
            // var customer = new Customer();

            customer.GreetandCombineNames("Ben", "Spark");

            Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
            Assert.Contains(",", customer.GreetMessage);
            Assert.StartsWith("Hello", customer.GreetMessage);
            Assert.EndsWith("Spark", customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        }

        [Fact]
        public void GetNotNullifGreetedwithoutLastName()
        {
            customer.GreetandCombineNames("Ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));

        }

        // How to test for exceptions
        // that an exception is thrown for instance
        [Fact]
        public void GetExceptionifGreetedwithoutFirstName()
        {
            var exceptionDetails =
            // assert that an argument exception is called when GreetandCombineNames is called
            // without a first name.
            Assert.Throws<ArgumentException>(() => customer.GreetandCombineNames("", "Spark"));
            // assert that we have a certain exception message that we know beforehand
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            // how to assert an exception is being thrown
            Assert.Throws<ArgumentException>(() => customer.GreetandCombineNames("", "Spark"));

        }

        [Fact]
        public void ReturnsBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void ReturnsPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}