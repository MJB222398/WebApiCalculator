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
        }

        [Test]
        public void GivenWhiteSpaceInputErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "1 + 3"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
        }

        [Test]
        public void GivenDecimalInputErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "1.3+4"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
        }

        [Test]
        public void GivenBracketsInputErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "2*(2+8)"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
        }

        [Test]
        public void GivenInputEndsWithOperatorErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "2*2+8+"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
        }

        [Test]
        public void GivenInputBeginsWithOperatorErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "+2*2+8"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
        }

        [Test]
        public void GivenInputIsPurelyOperatorErrorIsThrownAndNoResultGiven()
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = "+"
            };

            var errors = viewModel.Validate();

            Assert.IsNotEmpty(errors);
        }

        [TestCase("782*2+890")]
        [TestCase("12*2+890/2")]
        [TestCase("1")]
        [TestCase("31")]
        [TestCase("782")]
        [TestCase("2+7")]
        public void GivenValidInputErrorIsNotThrownAndResultIsGiven(string expressionInput)
        {
            var viewModel = new CalculationViewModel()
            {
                Expression = expressionInput
            };

            var errors = viewModel.Validate();

            Assert.IsEmpty(errors);
        }
    }
}