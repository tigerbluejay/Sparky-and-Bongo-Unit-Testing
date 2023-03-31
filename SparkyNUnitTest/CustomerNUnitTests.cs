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
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void GetGreetingandCombinedNames()
        {
            // replaced by the setup method
            // var customer = new Customer();

            customer.GreetandCombineNames("Ben", "Spark");

            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
            Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");

            //other functionalities
            Assert.That(customer.GreetMessage, Does.Contain(","));
            Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
            Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
            Assert.That(customer.GreetMessage, Does.Contain("ben").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

        }

        [Test]
        public void GetNullforGreetMessageProp()
        {
            // replaced by the setup method
            // var customer = new Customer();

            Assert.IsNull(customer.GreetMessage);
        }
        [Test]
        public void GetDiscountinRange()
        {
            int result = customer.Discount;
            
            // assert a value within a range
            Assert.That(result, Is.InRange(10, 25));
        }

        // Multiple assertions allow you to have a list of asserts within one test method
        // and check all of the asserts, instead of having the check stopped
        // on the remaining asserts if one prior fails first
        [Test]
        public void GetGreetingandCombinedNames2()
        {
            // replaced by the setup method
            // var customer = new Customer();

            customer.GreetandCombineNames("Ben", "Spark");

            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Does.Contain(","));
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("ben").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GetNotNullifGreetedwithoutLastName()
        {
            customer.GreetandCombineNames("Ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));

        }

        // How to test for exceptions
        // that an exception is thrown for instance
        [Test]
        public void GetExceptionifGreetedwithoutFirstName()
        {
            var exceptionDetails =
                // assert that an argument exception is called when GreetandCombineNames is called
                // without a first name.
                Assert.Throws<ArgumentException>(() => customer.GreetandCombineNames("", "Spark"));
            // assert that we have a certain exception message that we know beforehand
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            // alternatively we can combine both assertions in a That
            Assert.That(() => customer.GreetandCombineNames("", "Spark"), 
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            
            // how to assert an exception is being thrown
            Assert.Throws<ArgumentException>(() => customer.GreetandCombineNames("", "Spark"));

            // alternatively we use That
            Assert.That(() => customer.GreetandCombineNames("", "Spark"), Throws.ArgumentException);
            
        }

        [Test]
        public void ReturnsBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void ReturnsPlatinumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
// CONTINUE ON VIDEO 33 "SETUP INHERITANCE"