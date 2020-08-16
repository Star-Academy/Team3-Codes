using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Search.Model
{
    public class RegexOperator
    {
         public static List<string> AssortTheWords(string input, Regex regex, int groupOfWordInRegex)
         {
             var wordsThatMatch = new List<string>();
             
             var matches = regex.Matches(input);
             
             if(matches != null)
             {
                 foreach(Match m in matches)
                    wordsThatMatch.Add(m.Groups[2].Value);
             }
             
            return wordsThatMatch;
         }
    }
}