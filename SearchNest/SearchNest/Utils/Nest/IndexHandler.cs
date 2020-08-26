using System.Collections.Generic;
using Nest;
using SearchNest.Model;

namespace SearchNest.Utils.Nest
{
    public class IndexHandler
    {
        private readonly string index;
        private readonly ElasticClient client;
        public IndexHandler(string index, ElasticClient client)
        {
            this.index = index;
            this.client = client;
        }
        public void CreateMapping()
        {
            var response = client.Indices.Create(index, c => c
                            .Map<Document>(m => m.AutoMap()
                             .Properties(pps => pps
                                .Number(s => s
                                    .Name(e => e.Id))
                                .Text(t => t
                                .Name(n => n.Text)
                                .Analyzer("whitespace")
                                .Analyzer("lowercase")))));

            ResponseValidator.handleValidation(response , "Index Creating");

        }

        public void BulkDocs(List<Document> documents)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var doc in documents)
            {
                bulkDescriptor.Index<Document>(x => x
                    .Index(index)
                     .Document(doc)
                );
            }
            ResponseValidator.handleValidation(client.Bulk(bulkDescriptor),"Bulking docs");
        }
    }
}