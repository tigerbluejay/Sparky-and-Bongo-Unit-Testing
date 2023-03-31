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
    public class FibonacciNUnitTests
    {
        private Fibonacci fibonacciObject { get; set; }
        [SetUp]
        public void Setup()
        {
            fibonacciObject = new Fibonacci();
        }

        [Test]
        public void MultipleScenariosforRange1()
        {
            fibonacciObject.Range = 1;
            List<int> control = new List<int>() { 0 };

            var result = fibonacciObject.GetFibonacciSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Empty);
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.EquivalentTo(control));
            });
        }

        [Test]
        public void MultipleScenariosforRange6()
        {
            fibonacciObject.Range = 6;
            List<int> control = new List<int>() { 0, 1, 1, 2, 3, 5 };

            var result = fibonacciObject.GetFibonacciSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain(3));
                Assert.That(result.Count(), Is.EqualTo(6));
                Assert.That(result, Has.No.Member(4));
                Assert.That(result, Is.EquivalentTo(control));
            });
        }

    }
}
