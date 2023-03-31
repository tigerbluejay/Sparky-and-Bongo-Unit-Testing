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
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers()
        {
            // Arrange
            Calculator calc = new();

            // Act
            int result = calc.AddNumbers(10, 20);

            // Assert
            Assert.AreEqual(30, result);
            Assert.That(30, Is.EqualTo(result));
        }

        [Test]
        public void IsOddNumber()
        {
            Calculator calc = new();

            bool result = calc.IsOddNumber(1);

            Assert.That(result, Is.True);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEvenNumber()
        {
            Calculator calc = new();

            bool result = calc.IsOddNumber(2);

            Assert.That(result, Is.False);
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber(int a)
        {
            Calculator calc = new();

            bool result = calc.IsOddNumber(a);

            Assert.That(result, Is.True);
            Assert.IsTrue(result);
        }


        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        // returns bool
        public bool IsEvenorOddNumber(int a)
        {
            Calculator calc = new();

            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] // result is 15.9
        [TestCase(5.43, 10.53)] // result is 15.96
        [TestCase(5.49, 10.59)] // result is 16.08
        public void AddDoubles(double a, double b)
        {
            // Arrange
            Calculator calc = new();

            // Act
            double result = calc.AddDoublesNumbers(a, b);

            // Assert
            // delta value (the last argument) checks for a range
            Assert.AreEqual(15.9, result, .2);
        }

        [Test]
        public void GetValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; // for range 5-10 for instance

            List<int> result = calc.GetOddNumbersfromRange(5, 10);

            // for collections we use equivant to
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.AreEqual(expectedOddRange, result);

            // other functionalities
            Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            // Assert.That(result, Is.Ordered.Descending)
            Assert.That(result, Is.Unique); // checks that all results in the collection are unique

        }
    }
}
