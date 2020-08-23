using Nest;
using SearchNest.Model;

namespace SearchNest.Utils.Nest
{
    public class IndexHandler
    {
       public static CreateIndexResponse CreateMapping(ElasticClient client)
        {
            var index = "document";
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
                            .Map<Document>(m => m
                                .Properties(pr => pr
                                        .Number(t => t
                                            .Name(n => n.ID)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                    .Name("ngram")
                                                    .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.Text)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer"))))
                                        .Text(t => t
                                            .Name(n => n.Name)
                                                .Fields(f => f
                                                    .Text(ng => ng
                                                        .Name("ngram")
                                                        .Analyzer("my-ngram-analyzer")))))));  
                                        
           return response;                                     

        } 
    }
}