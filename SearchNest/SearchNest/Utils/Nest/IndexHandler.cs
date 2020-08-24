using System.Collections.Generic;
using Nest;
using SearchNest.Model;

namespace SearchNest.Utils.Nest
{
    public class IndexHandler
    {
        string index;
        ElasticClient client;
        public IndexHandler(string index, ElasticClient client)
        {
            this.index = index;
            this.client = client;
        }
        public CreateIndexResponse CreateMapping()
        {
            var response = client.Indices.Create(index, c => c
                            .Map<Document>(m => m.AutoMap()
                             .Properties(pps => pps 
                                .Number(s => s
                                .Name(e => e.Id)
                            ))));

            return response;

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
            client.Bulk(bulkDescriptor);
        }
    }
}