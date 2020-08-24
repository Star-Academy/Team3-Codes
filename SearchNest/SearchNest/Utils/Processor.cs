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
                string text = reader.CurrentText();
                var document = new Document(text,i,reader.CurrentName());
                documents.Add(document);
                i++;
            }
            return i; // return number of documents
        }

        public IResponse Process(string input, ElasticClient client, string index)
        {
            string wordsWithPlusSign = RegexOperator.AssortTheWords(input, PLUS_REGEX, 2);
            string wordsWithMinusSign = RegexOperator.AssortTheWords(input, MINUS_REGEX, 2);
            string noneSignWords = RegexOperator.AssortTheWords(input, NONE_SIGN_REGEX, 1);
            var query = new SearchQuery(client,index);
            return query.SearchForAllWords(wordsWithPlusSign,wordsWithMinusSign,noneSignWords);
        }
    }
}