using System.Text.RegularExpressions;

namespace WebApiCalculator.Resources
{
    public static class RegExPatterns
    {
        private static string attempt0 = "^[0-9][0-9\\+\\-\\*\\\\]*[0-9]$";
        private static string attempt1 = "^(([0-9]{1,}[\\+\\-\\/\\*]){1,9}?)[0-9]*$";
        private static string attempt2 = "^((([0-9]{1,})([\\+\\-\\/\\*])){1,9}?)([0-9]*)$";
        private static string attempt3 = "^(?:(?:([0-9]{1,})([\\+\\-\\/\\*])){1,9})([0-9]+)$";
        private static string attempt4 = "^(?:(?:([0-9]+)([\\+\\-\\/\\*]))+)([0-9]+)$";

        public static Regex ValidInputPattern = new Regex("^(?:(?:([0-9]+)([\\+\\-\\/\\*]))+)([0-9]+)$");
    }
}
