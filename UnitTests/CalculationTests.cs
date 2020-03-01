using NUnit.Framework;
using WebApiCalculator.Helpers;

namespace UnitTests
{
    public class CalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAdditionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("1+3");

            Assert.AreEqual("4", calculationResult);
        }

        [Test]
        public void GivenSubtractionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("44-3");

            Assert.AreEqual("41", calculationResult);
        }

        [Test]
        public void GivenMultiplicationCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12*4");

            Assert.AreEqual("48", calculationResult);
        }

        [Test]
        public void GivenDivisionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12/4");

            Assert.AreEqual("3", calculationResult);
        }

        [Test]
        public void GivenMultipleAdditionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("1+3+9");

            Assert.AreEqual("13", calculationResult);
        }

        [Test]
        public void GivenMultipleSubtractionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("44-3-12");

            Assert.AreEqual("29", calculationResult);
        }

        [Test]
        public void GivenMultipleMultiplicationCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12*4*2");

            Assert.AreEqual("96", calculationResult);
        }

        [Test]
        public void GivenMultipleDivisionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12/4/3");

            Assert.AreEqual("1", calculationResult);
        }

        [Test]
        public void GivenCalculationGivingNegativeResultCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12-25");

            Assert.AreEqual("-13", calculationResult);
        }

        [Test]
        public void GivenCalculationContainingDivideByZeroAnErrorIsShown()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12+39*2/0");

            Assert.AreEqual("Invalid expression - there was an attempt to divide by zero", calculationResult);
        }

        [Test]
        public void GivenCalculationWithMultipleTypesOfOperatorCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("1+10*4*2-8+0");

            Assert.AreEqual("73", calculationResult);
        }

        [Test]
        public void GivenCalculationResultingInDecimalCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("10/4");

            Assert.AreEqual("2.5", calculationResult);
        }
    }
}