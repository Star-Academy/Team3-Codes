using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Search.Model
{
    public class RegexOperator
    {
        Regex PLUS_REGEX = new Regex("(\\+)(\\w*)");
        Regex MINUS_REGEX = new Regex("(-)(\\w*)");
        Regex NONE_SIGN_REGEX =new Regex("^(\\w*)");

         public static List<string> AssortTheWords(string input, Regex regex, int groupOfWordInRegex)
         {
             List<string> wordsThatMatch = new List<string>();
             
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