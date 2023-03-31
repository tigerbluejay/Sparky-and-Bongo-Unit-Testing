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
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator { get; set;}
        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GetGradeofA()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            var result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GetGradeofB()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            var result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GetGradeofC()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            var result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void GetGradeofB2ndScenario()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            var result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GetGradeofF(int a, int b)
        {
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            var result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrades(int a, int b)
        {
            gradingCalculator.Score = a;
            gradingCalculator.AttendancePercentage = b;

            return gradingCalculator.GetGrade();
        }

    }
}
