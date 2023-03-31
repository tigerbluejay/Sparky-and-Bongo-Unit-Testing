using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers()
        {
            // Arrange
            Calculator calc = new();

            // Act
            int result = calc.AddNumbers(10, 20);

            // Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddNumber()
        {
            Calculator calc = new();

            bool result = calc.IsOddNumber(1);

            Assert.True(result);
        }

        [Fact]
        public void IsEvenNumber()
        {
            Calculator calc = new();

            bool result = calc.IsOddNumber(2);

            Assert.False(result);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddNumber2(int a)
        {
            Calculator calc = new();

            bool result = calc.IsOddNumber(a);

            Assert.True(result);
        }


        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        // returns bool
        public void IsEvenorOddNumber(int a, bool expectedResult)
        {
            Calculator calc = new();

            var result = calc.IsOddNumber(a);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)] // result is 15.9
        [InlineData(5.43, 10.53)] // result is 15.96
        [InlineData(5.49, 10.59)] // result is 16.08
        public void AddDoubles(double a, double b)
        {
            // Arrange
            Calculator calc = new();

            // Act
            double result = calc.AddDoublesNumbers(a, b);

            // Assert
            // delta value (the last argument) checks for a range in NUnit
            // in XUnit we have a Precision which is an integer, representing to how many decimals it should round
            Assert.Equal(15.9, result, 0);
        }

        [Fact]
        public void GetValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; // for range 5-10 for instance

            List<int> result = calc.GetOddNumbersfromRange(5, 10);

            // for collections we use equivant to in NUnit and Equal in XUnit
            Assert.Equal(expectedOddRange, result);

            // other functionalities
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u=>u), result);            
        }
    }
}
