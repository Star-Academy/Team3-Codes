using System.Collections.Generic;
using System.Text.RegularExpressions;
using Search.Utils;
namespace Search.Model
{
    public class Processor
    {
        private Dictionary<string, HashSet<int>>  tokens;
        private  IReader reader;
        Regex PLUS_REGEX = new Regex("(\\+)(\\w*)");
        Regex MINUS_REGEX = new Regex("(-)(\\w*)");
        Regex NONE_SIGN_REGEX =new Regex("^(\\w*)");

    public Processor(IReader reader) {
        this.tokens = new Dictionary<string, HashSet<int>>(); 
        this.reader = reader;
    }

    public Dictionary<string, HashSet<int>> GetTokens() {
        return this.tokens;
    }

    public int FillTheMap() {
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        int i = 0;
        while (reader.MoveNext()) {
            invertedIndex.updateTheMap(reader.Current(), i);
            i++;
        }
        return i; 
    }

    public HashSet<int> process(string input, int numberOfDocs) {
        List<string> wordsWithPlusSign = RegexOperator.AssortTheWords(input, PLUS_REGEX, 2);
        List<string> wordsWithMinusSign = RegexOperator.AssortTheWords(input, MINUS_REGEX, 2);
        List<string> noneSignWords = RegexOperator.AssortTheWords(input, NONE_SIGN_REGEX, 1);
        And and = new And();
        Or or = new Or();
        Subtract sub = new Subtract();

        var beforeMinus = and.Apply(and.ApplyOnAll(noneSignWords, tokens),
                or.ApplyOnAll(wordsWithPlusSign, tokens));

        if (noneSignWords.Count == 0 && wordsWithPlusSign.Count == 0)
            for (int i = 0; i < numberOfDocs; i++)
                beforeMinus.Add(i);
        return sub.Apply(beforeMinus, or.ApplyOnAll(wordsWithMinusSign, tokens));

    }
    }
}