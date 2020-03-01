using System.Text.RegularExpressions;

namespace WebApiCalculator.Resources
{
    public static class RegExPatterns
    {
        public static Regex ValidInputPattern = new Regex("^(?:(?:([0-9]+)([\\+\\-\\/\\*]))+)([0-9]+)$");

        public static Regex HasOperationToPerformPattern = new Regex("^.*[\\d][\\+\\-\\/\\*][\\d].*$");

        public static Regex MultiplicationCalculationPattern = new Regex("^.*?((\\d+\\.?\\d*)(\\*)(\\d+\\.?\\d*)).*?$");

        public static Regex DivisionCalculationPattern = new Regex("^.*?((\\d+\\.?\\d*)(\\/)(\\d+\\.?\\d*)).*?$");

        public static Regex AdditionCalculationPattern = new Regex("^.*?((\\d+\\.?\\d*)(\\+)(\\d+\\.?\\d*)).*?$");

        public static Regex SubtractionCalculationPattern = new Regex("^.*?((\\-?\\d+\\.?\\d*)(\\-)(\\d+\\.?\\d*)).*?$");
    }
}
