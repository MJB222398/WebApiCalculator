using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
            decimal result;

            var multiplicationCalculation = RegExPatterns.MultiplicationCalculationPattern.Match(expression);
            if (multiplicationCalculation.Success && multiplicationCalculation.Groups.Count > 3)
            {
                result = PerformOperation(multiplicationCalculation, OperationType.Multiplication);
            }
            else
            {
                var divisionCalculation = RegExPatterns.DivisionCalculationPattern.Match(expression);
                if (divisionCalculation.Success && divisionCalculation.Groups.Count > 3)
                {
                    result = PerformOperation(divisionCalculation, OperationType.Division);
                }
                else
                {
                    var additionCalculation = RegExPatterns.AdditionCalculationPattern.Match(expression);
                    if (additionCalculation.Success && additionCalculation.Groups.Count > 3)
                    {
                        result = PerformOperation(additionCalculation, OperationType.Addition);
                    }
                    else
                    {
                        var subtractionCalculation = RegExPatterns.SubtractionCalculationPattern.Match(expression);
                        if (subtractionCalculation.Success && subtractionCalculation.Groups.Count > 3)
                        {
                            result = PerformOperation(subtractionCalculation, OperationType.Subtraction);
                        }
                    }
                }
            }

            return expression;
        }

        private decimal PerformOperation(Match match, OperationType operationType)
        {
            if (!int.TryParse(match.Groups[1].Value, out int leftHandOperand))
                throw new Exception($"{nameof(leftHandOperand)} not found");

            if (!int.TryParse(match.Groups[3].Value, out int rightHandOperand))
                throw new Exception($"{nameof(rightHandOperand)} not found");

            decimal result;
            switch (operationType)
            {
                case OperationType.Multiplication:
                    result = leftHandOperand * rightHandOperand;
                    break;
                case OperationType.Division:
                    result = leftHandOperand / rightHandOperand;
                    break;
                case OperationType.Addition:
                    result = leftHandOperand + rightHandOperand;
                    break;
                case OperationType.Subtraction:
                    result = leftHandOperand - rightHandOperand;
                    break;
                default:
                    throw new Exception($"Invalid operation: {operationType}");
            }

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
