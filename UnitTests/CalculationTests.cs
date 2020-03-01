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

            Assert.AreEqual(calculationResult, "4");
        }

        [Test]
        public void GivenSubtractionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("44-3");

            Assert.AreEqual(calculationResult, "41");
        }

        [Test]
        public void GivenMultiplicationCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12*4");

            Assert.AreEqual(calculationResult, "48");
        }

        [Test]
        public void GivenDivisionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12/4");

            Assert.AreEqual(calculationResult, "3");
        }

        [Test]
        public void GivenMultipleAdditionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("1+3+9");

            Assert.AreEqual(calculationResult, "13");
        }

        [Test]
        public void GivenMultipleSubtractionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("44-3-12");

            Assert.AreEqual(calculationResult, "29");
        }

        [Test]
        public void GivenMultipleMultiplicationCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12*4*2");

            Assert.AreEqual(calculationResult, "96");
        }

        [Test]
        public void GivenMultipleDivisionCalculationCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12/4/3");

            Assert.AreEqual(calculationResult, "1");
        }

        [Test]
        public void GivenCalculationGivingNegativeResultCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12-25");

            Assert.AreEqual(calculationResult, "-13");
        }

        [Test]
        public void GivenCalculationContainingDivideByZeroAnErrorIsShown()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("12+39*2/0");

            Assert.AreEqual(calculationResult, "Invalid expression - there was an attempt to divide by zero");
        }

        [Test]
        public void GivenCalculationWithMultipleTypesOfOperatorCorrectResultIsReturned()
        {
            var calculationResult = CalculationHelper.GetExpressionResult("1+10*4*2-8+0");

            Assert.AreEqual(calculationResult, "73");
        }
    }
}