using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class FibonacciXUnitTests
    {
        private Fibonacci fibonacciObject { get; set; }
        public FibonacciXUnitTests()
        {
            fibonacciObject = new Fibonacci();
        }

        [Fact]
        public void MultipleScenariosforRange1()
        {
            fibonacciObject.Range = 1;
            List<int> control = new List<int>() { 0 };

            var result = fibonacciObject.GetFibonacciSeries();

            Assert.NotEmpty(result);
            Assert.Equal(control.OrderBy(u=>u), result);
            // Assert.That(result, Is.EquivalentTo(control)); in NUnit
            Assert.True(result.SequenceEqual(control));
        }

        [Fact]
        public void MultipleScenariosforRange6()
        {
            fibonacciObject.Range = 6;
            List<int> control = new List<int>() { 0, 1, 1, 2, 3, 5 };

            var result = fibonacciObject.GetFibonacciSeries();

            Assert.Contains(3, result);
            Assert.Equal(6, result.Count());
            Assert.DoesNotContain(4, result);
            // Assert.That(result, Is.EquivalentTo(control)); in NUnit
            Assert.Equal(control, result);
        }

    }
}
