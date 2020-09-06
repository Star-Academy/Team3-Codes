using System.Collections.Generic;
using Nest;

namespace NestTest.Model
{
    public class Query
    {
        ElasticClient client ;
        string index ;
        public Query( ElasticClient client , string index ){
            this.client = client ;
            this.index = index ;
        }
        public IResponse BoolQuerySample1(ElasticClient client, string index)
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
        public IResponse MultiMatchQueySample1(ElasticClient client, string index)
        {

            return client.Search<Person>(s => s
                   .Index(index)
                   .Query(q => q.MultiMatch(c => c
                   .Fields(f => f.Field(p => p.Address).Field(p => p.About)).Operator(Operator.And)
                   .Query("gates").Query("wyoming"))));
        }
        public IResponse GeoDistanceQuerySample(ElasticClient client, string index)
        {

            return client.Search<Person>(p => p
            .Index(index)
            .Query(q =>q.GeoDistance(g => g
            .Field(p => p.Location)
            .DistanceType(GeoDistanceType.Arc)
            .Location(43, 77)
            .Distance("1500m")
            .ValidationMethod(GeoValidationMethod.IgnoreMalformed)))) ;

          
        }

        public IResponse RangeQuerySample(ElasticClient client, string index)
        {

            return client.Search<Person>(p => p
            .Index(index)
            .Query(q =>q.Range(r =>r
            .Field(p => p.Age)
            .LessThanOrEquals(25)
            .GreaterThanOrEquals(23))));
          
        }
        public IResponse MatchQuerySample(ElasticClient client, string index)
        {
            return client.Search<Person>(s => s
                    .Index(index)
                    .Query(q => q
                        .Match(match => match
                            .Field(p => p.EyeColor).MinimumShouldMatch(1)
                            .Query("blue").Query("green"))));
        }

        public IResponse FuzzyQuerySample(ElasticClient client, string index)
        {
            return client.Search<Person>(s => s
                    .Index(index)
                    .Query(q => q
                        .Match(match => match
                            .Field(p => p.About)
                            .Fuzziness(Fuzziness.AutoLength(1, 2))
                            .Query("labor"))));
        }
        public ISearchResponse<Person> AggregationQuerySample(){
         return client.Search<Person>(s => s
                    .Index(index)
                    .Aggregations(a => a
                    .Terms("colors", st => st
                    .Field("eyeColor.keyword"))));
                                                                    
        }
    }
}
