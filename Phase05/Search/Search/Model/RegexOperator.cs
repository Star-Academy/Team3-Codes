using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Search.Model
{
    public class RegexOperator
    {
         public static List<string> AssortTheWords(string input, Regex regex, int groupOfWordInRegex)
         {
            List<string> wordsThatMatch = new List<string>();
             
            var matches = regex.Matches(input);
             
            if(matches == null)
            {
                throw new ArgumentNullException();
            }
            return matches.Select(m => m.Groups[2].Value).ToList();

             
         }
    }
}