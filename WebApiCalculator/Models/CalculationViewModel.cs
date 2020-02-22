using System.ComponentModel.DataAnnotations;

namespace WebApiCalculator.Models
{
    public class CalculationViewModel
    {
        [Display(Name = "Expression: ")]
        public string Expression { get; set; }

        [Display(Name = "Result: ")]
        public string Result { get; set; }
    }
}