using System;
using System.Text.RegularExpressions;
using WebApiCalculator.Resources;

namespace WebApiCalculator.Helpers
{
    public static class CalculationHelper
    {
        public static string GetExpressionResult(string expression)
        {
            while (RegExPatterns.HasOperatorPattern.IsMatch(expression))
                expression = PerformHighestPriorityOperation(expression);

            return expression;
        }

        private static string PerformHighestPriorityOperation(string expression)
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

        private static decimal PerformOperation(Match match, OperationType operationType)
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
    }
}
