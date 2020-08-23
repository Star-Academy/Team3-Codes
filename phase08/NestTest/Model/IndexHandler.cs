using Nest;
using NestTest.Model;

namespace NestTest
{
    public class IndexHandler
    {
        public static CreateIndexResponse CreateMapping(ElasticClient client)
        {
            var index = "people";
            var response = client.Indices.Create(index,
                    s => s.Settings(settings => settings
                        .Setting("max_ngram_diff", 7)
                        .Analysis(analysis => analysis
                            .TokenFilters(tf => tf
                                .NGram("my-ngram-filter", ng => ng
                                    .MinGram(3)
                                    .MaxGram(10)))
                            .Analyzers(analyzer => analyzer
                                .Custom("my-ngram-analyzer", custom => custom
                                    .Tokenizer("standard")
                                    .Filters("lowercase", "my-ngram-filter")))))
                            .Map<Person>(m => m
                                .Properties(pr => pr
                                        .Number(t => t
                                            .Name(n => n.Age)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                    .Name("ngram")
                                                    .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.EyeColor)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("keyword")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.Name)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))  
                                        .Text(t => t
                                            .Name(n => n.Gender)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))      
                                        .Text(t => t
                                            .Name(n => n.Company)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.Email)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.Phone)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.Address)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.About)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Date(t => t
                                            .Name(n => n.RegistrationDate)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .GeoPoint(t => t
                                            .Name(n => n.Location)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))                                                                                                                                        
                                                )));
           return response;                                     

        }
    }
}