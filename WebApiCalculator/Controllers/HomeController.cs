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

        private decimal GetExpressionResult(string expression)
        {
            var operandList = expression.Split(new char[] { '+', '-', '*', '/' });
            var operatorList = expression.Where(x => RegExPatterns.OperatorPattern.IsMatch(x.ToString())).Select(x => x.ToString()).ToList();

            if (operandList.Length != operatorList.Count + 1)
                throw new Exception("Something went wrong!");

            return 156.34M;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
