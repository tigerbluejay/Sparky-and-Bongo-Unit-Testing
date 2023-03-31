using Bongo.Models.ModelValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Models.Tests
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        [Test]
        public void DateisValid()
        {
            //Arrange
            DateInFutureAttribute dateInFuture = new(()=> DateTime.Now);
            //Act
            var result = dateInFuture.IsValid(DateTime.Now.AddSeconds(100));
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestCase(100, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        public bool DateisValid(int timeAdditional)
        {
            DateInFutureAttribute dateInFuture = new(() => DateTime.Now);
            
            return dateInFuture.IsValid(DateTime.Now.AddSeconds(timeAdditional));
        }

        [Test]
        public void ErrorMessageisSet()
        {
            var result = new DateInFutureAttribute();

            Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
}
