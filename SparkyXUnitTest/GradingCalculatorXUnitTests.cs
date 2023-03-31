using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gradingCalculator { get; set;}

        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void GetGradeofA()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            var result = gradingCalculator.GetGrade();

            Assert.Equal("A", result);
        }

        [Fact]
        public void GetGradeofB()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            var result = gradingCalculator.GetGrade();

            Assert.Equal("B", result);
        }

        [Fact]
        public void GetGradeofC()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            var result = gradingCalculator.GetGrade();

            Assert.Equal("C", result);
        }

        [Fact]
        public void GetGradeofB2ndScenario()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            var result = gradingCalculator.GetGrade();

            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GetGradeofF(int a, int b)
        {
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            var result = gradingCalculator.GetGrade();

            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrades(int a, int b, string expectedResult)
        {
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            string result = gradingCalculator.GetGrade();

            Assert.Equal(expectedResult, result);
        }

    }
}
