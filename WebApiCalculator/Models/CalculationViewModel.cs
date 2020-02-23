using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApiCalculator.Models
{
    public class CalculationViewModel
    {
        [Display(Name = "Expression: ")]
        public string Expression { get; set; }

        [Display(Name = "Result: ")]
        public string Result { get; set; }

        public void Validate(ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(Expression))
                modelState.AddModelError(nameof(Expression), "You must enter an expression to evaluate");
        }
    }
}