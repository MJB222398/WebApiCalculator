using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using WebApiCalculator.Models;
using WebApiCalculator.Resources;

namespace WebApiCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CalculationViewModel());
        }

        [HttpPost]
        public IActionResult PerformCalculation(CalculationViewModel model)
        {
            var errors = model.Validate();

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                    ModelState.AddModelError(error.Key, error.Value);

                return View("Index", model);
            }

            model.Result = GetExpressionResult(model.Expression);

            return View("Index", model);
        }

        private string GetExpressionResult(string expression)
        {
            while (RegExPatterns.HasOperatorPattern.IsMatch(expression))
                expression = PerformHighestPriorityOperation(expression);

            return expression;
        }

        private string PerformHighestPriorityOperation(string expression)
        {
            var multiplicationCalculation = RegExPatterns.MultiplicationCalculationPattern.Match(expression);
            var divisionCalculation = RegExPatterns.DivisionCalculationPattern.Match(expression);
            var additionCalculation = RegExPatterns.AdditionCalculationPattern.Match(expression);
            var subtractionCalculation = RegExPatterns.SubtractionCalculationPattern.Match(expression);

            if (multiplicationCalculation != null)
            {
                var match = multiplicationCalculation;
            }

            return expression;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
