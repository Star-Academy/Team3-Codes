using System.Collections.Generic;
using System.Text.RegularExpressions;
using Search.Model;
using SearchNest.Utils.Reader;

namespace SearchNest.Utils
{
    public class Processor
    {
        private Dictionary<string, HashSet<int>>  tokens;
        private  IReader reader;
        Regex PLUS_REGEX = new Regex("(\\+)(\\w*)");
        Regex MINUS_REGEX = new Regex("(-)(\\w*)");
        Regex NONE_SIGN_REGEX =new Regex("^(\\w+)");

    public Processor(IReader reader) {

        this.tokens = new Dictionary<string, HashSet<int>>(); 
        this.reader = reader;
    }

    public HashSet<int> Process(string input, int numberOfDocs) {

        var wordsWithPlusSign = RegexOperator.AssortTheWords(input, PLUS_REGEX, 2);
        var wordsWithMinusSign = RegexOperator.AssortTheWords(input, MINUS_REGEX, 2);
        var noneSignWords = RegexOperator.AssortTheWords(input, NONE_SIGN_REGEX, 1);
         
         return new HashSet<int>();

    }
    }
}