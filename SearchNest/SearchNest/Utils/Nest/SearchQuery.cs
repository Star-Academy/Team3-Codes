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
        public IResponse SearchForAllWords(List<string> wordsWithPlusSign, List<string> wordsWithMinusSign, List<string> noneSignWords)
        {
            return client.Search<Document>(s => s
                            .Index(index)
                            .Query(q => q
                                .Terms(c => c
                                    .Field(p => p.Text)
                                    .Terms(noneSignWords)
                                    )));

        }
    }
}