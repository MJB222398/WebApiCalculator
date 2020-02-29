using System.Text.RegularExpressions;

namespace WebApiCalculator.Resources
{
    public static class RegExPatterns
    {
        public static Regex ValidInputPattern = new Regex("^(?:(?:([0-9]+)([\\+\\-\\/\\*]))+)([0-9]+)$");

        public static Regex OperatorPattern = new Regex("^[\\+\\-\\/\\*]$");
    }
}
