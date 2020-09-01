using System.Collections.Generic;
using Nest;
using SearchNest.Model;

namespace SearchNest.Utils.Nest
{
    public class IndexHandler
    {
        private const string TOPIC_OF_CEARTING_INDEX_REQUEST = "Index Creating";
        private const string TOPIC_OF_BULKING_DOCS_REQUEST = "Bulking docs";
        private string index;
        private ElasticClient client;
        public IndexHandler(string index, ElasticClient client)
        {
            this.index = index;
            this.client = client;
        }
        public void InitIndexByDocuments<T>(List<T> documents) where T : class
        {
                CreateMapping();
                BulkDocs(documents);
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

            ResponseValidator.handleValidation(response, TOPIC_OF_CEARTING_INDEX_REQUEST);

        }

        public void BulkDocs<T>(List<T> documents) where T : class
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var doc in documents)
            {
                bulkDescriptor.Index<T>(x => x
                    .Index(index)
                     .Document(doc)
                );
            }
            ResponseValidator.handleValidation(client.Bulk(bulkDescriptor), TOPIC_OF_BULKING_DOCS_REQUEST);
        }

    }
}