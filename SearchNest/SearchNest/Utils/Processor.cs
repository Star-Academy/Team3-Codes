using System.Collections.Generic;
using System.Text.RegularExpressions;
using Search.Model;
using SearchNest.Utils.Reader;
using SearchNest.Model;
using SearchNest.Utils.Nest;
using Nest;

namespace SearchNest.Utils
{
    public class Processor
    {
        private List<Document> documents = new List<Document>();
        private IReader reader;
        Regex PLUS_REGEX = new Regex("(\\+)(\\w*)");
        Regex MINUS_REGEX = new Regex("(-)(\\w*)");
        Regex NONE_SIGN_REGEX = new Regex("( |^)(\\w+)");

        public Processor(IReader reader)
        {
            this.reader = reader;
        }

        public List<Document> GetDocuments()
        {
            return this.documents;
        }

        public int SerializeDocuments()
        {
            int i = 0;
            while (reader.MoveNext())
            {
                var text = reader.CurrentText();
                var document = new Document(text, i, reader.CurrentName());
                documents.Add(document);
                i++;
            }
            return i; // return number of documents
        }

        public ISearchResponse<Document> doProcess(string input, ElasticClient client, string index)
        {
            var wordsWithPlusSign = string.Join(" ",RegexOperator.AssortTheWords(input, PLUS_REGEX, 2));
            var wordsWithMinusSign = string.Join(" ",RegexOperator.AssortTheWords(input, MINUS_REGEX, 2));
            var noneSignWords = string.Join(" ",RegexOperator.AssortTheWords(input, NONE_SIGN_REGEX, 1));
            var query = new SearchQuery(client, index);
            return query.SearchForAllWords(wordsWithPlusSign, wordsWithMinusSign, noneSignWords);
        }
    }
}