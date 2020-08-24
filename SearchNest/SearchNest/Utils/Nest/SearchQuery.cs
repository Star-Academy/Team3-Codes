using System.Collections.Generic;
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
        public IResponse SearchForAllWords(string wordsWithPlusSign, string wordsWithMinusSign, string noneSignWords)
        {
            var response = client.Search<Document>(s => s
                                    .Index(index)
                                    .Query(q => q
                                        .Bool(b => b
                                            .Must(must => must
                                                .Match(match => match
                                                    .Field(p => p.Text)
                                                    .Query(noneSignWords)
                                                    .Operator(Operator.And)))
                                            .MustNot(must => must
                                                .Match(match => match
                                                    .Field(p => p.Text)
                                                    .Query(wordsWithMinusSign)))
                                            .Should(must => must
                                                .Match(match => match
                                                    .Field(p => p.Text)
                                                    .Query(wordsWithPlusSign)))
                                                    )));

            return response;
        }
    }
}