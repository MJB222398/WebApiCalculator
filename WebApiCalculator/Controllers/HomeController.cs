using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApiCalculator.Helpers;
using WebApiCalculator.Models;

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

            model.Result = CalculationHelper.GetExpressionResult(model.Expression);

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
