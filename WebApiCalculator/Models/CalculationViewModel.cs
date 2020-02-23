﻿using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using WebApiCalculator.Resources;

namespace WebApiCalculator.Models
{
    public class CalculationViewModel
    {
        [Display(Name = "Expression: ")]
        public string Expression { get; set; }

        [Display(Name = "Result: ")]
        public string Result { get; set; }

        public NameValueCollection Validate()
        {
            var errors = new NameValueCollection();

            if (string.IsNullOrWhiteSpace(Expression))
            {
                errors.Add(nameof(Expression), "You must enter an expression to evaluate");
            }
            else if (!RegExPatterns.ValidInputPattern.IsMatch(Expression))
            {
                errors.Add(nameof(Expression), "Please enter a valid expression");
            }

            return errors;
        }
    }
}