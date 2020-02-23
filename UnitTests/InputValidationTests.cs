using NUnit.Framework;
using WebApiCalculator.Models;

namespace UnitTests
{
    public class InputValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenNullInputErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = null
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
            Assert.That(string.IsNullOrWhiteSpace(viewModel.Result));
        }

        [Test]
        public void GivenAlphabeticInputErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "House"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
            Assert.That(string.IsNullOrWhiteSpace(viewModel.Result));
        }
    }
}