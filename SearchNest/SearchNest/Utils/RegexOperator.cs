using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SearchNest.Utils
{
    public class RegexOperator
    {
        public static IEnumerable<string> AssortTheWords(string input, Regex regex, int groupOfWordInRegex)
        {
            var wordsThatMatch = new List<string>();
            var matches = regex.Matches(input);
            if (matches != null)
            {
                foreach (Match m in matches)
                    wordsThatMatch.Add(m.Groups[groupOfWordInRegex].Value);
            }
            return wordsThatMatch;
        }
    }
}