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
    }
}