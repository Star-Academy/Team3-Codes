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
        public IResponse MultiMatchQuerySample1(List<int> wordsWithPlusSign, List<int> wordsWithMinusSign, List<int> noneSignWords)
        {

            var response = client.Search<Document>(s => s
                            .Index(index)
                             .Query(q => q
                                .Bool(b => b
                                    .Must(must => must
                                        .Terms(c => c
                                        .Field(p => p.Text)
                                        .Terms(noneSignWords))))));

            return response;

        }
    }
}