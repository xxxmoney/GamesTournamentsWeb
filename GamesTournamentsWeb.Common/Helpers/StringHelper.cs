using System.Text.RegularExpressions;

namespace GamesTournamentsWeb.Common.Helpers;

public class StringHelper
{
    public static string ToSnakeCase(string input)
    {
        return string.IsNullOrWhiteSpace(input) ? input : Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}