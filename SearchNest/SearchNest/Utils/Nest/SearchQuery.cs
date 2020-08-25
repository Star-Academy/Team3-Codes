using Nest;
using SearchNest.Model;
namespace SearchNest.Utils.Nest
{
    public class SearchQuery
    {
        ElasticClient client;
        string index;
        public SearchQuery(ElasticClient client, string index)
        {
            this.client = client;
            this.index = index;
        }
        public ISearchResponse<Document> SearchForAllWords(string wordsWithPlusSign, string wordsWithMinusSign, string noneSignWords)
        {
            var response = client.Search<Document>(s => s
                                   .Index(index)
                                   .Size(1000)
                                   .Query(q => q
                                       .Bool(b => b
                                           .Must(must => must
                                               .Match(match => match
                                                   .Field(p => p.Text)
                                                   .Query(noneSignWords)
                                                   .Operator(Operator.And)
                                                  ))
                                           .Must(must => must
                                               .Match(match => match
                                                   .Field(p => p.Text)
                                                   .Query(wordsWithPlusSign)
                                                   ))
                                           .MustNot(must => must
                                               .Match(match => match
                                                   .Field(p => p.Text)
                                                   .Query(wordsWithMinusSign)))
                                                   )));

            ResponseValidator.handleValidation(response,"Searching Query");
            return response ;

        }
    }
}