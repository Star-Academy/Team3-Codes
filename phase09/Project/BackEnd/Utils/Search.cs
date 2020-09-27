using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using SearchNest.Model;
using SearchNest.Utils;
using SearchNest.Utils.Nest;
using SearchNest.Utils.Reader;

namespace Project.Utils
{
    public class Search
    {
        private static readonly string path = "..\\..\\..\\SearchNest\\SearchNest\\Resources";
        private IndexHandler indexHandler;
        private ElasticClient client ;
        private Processor processor ;

        public Search()
        {
            Connect();
            this.indexHandler = new IndexHandler("documents", client);
            this.processor = new Processor(new FileReader(path));
        }
        public void init(){
            
        }

        public void Connect()
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri).EnableDebugMode();
            client = new ElasticClient(connectionSettings);
            ResponseValidator.handleValidation(client.Ping(), "Connecting to Server");
        }

        public void InitializeIndex()
        {

            if (!client.Indices.Exists("documents").Exists)
            {
                processor.SerializeDocuments();
                indexHandler.InitIndexByDocuments<Document>(processor.GetDocuments());
            }
        }

        public IEnumerable<Document> SearchForSuitableDocs(string input){
            var responseOfSearchQuery = processor.DoProcessOfSearch(input, client, "documents");
            return responseOfSearchQuery.Documents.OrderByDescending(s => s.Id);
        }
    }
}