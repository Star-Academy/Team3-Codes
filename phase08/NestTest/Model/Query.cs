using System.Collections.Generic;
using Nest;

namespace NestTest.Model
{
    public class Query
    {
        public static IResponse BoolQuerySample1(ElasticClient client, string index)
        {
            QueryContainer query = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "about",
                        Query = "Labore"
                    }
                }
            };
            var response = client.Search<Dictionary<string, object>>(s => s
                .Index(index)
                .Query(q => query));
            return response;
        }
    }
}