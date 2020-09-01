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
    public class Manager
    {
        private static readonly string path = "Resources";
        public IEnumerable<string> Search(string input){

            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri).EnableDebugMode();
            var client = new ElasticClient(connectionSettings);
            ResponseValidator.handleValidation(client.Ping(), "Connecting to Server");

            var indexHandler = new IndexHandler("documents", client);
            var processor = new Processor(new FileReader(path));

            if (!client.Indices.Exists("documents").Exists)
            {
                processor.SerializeDocuments();
                indexHandler.InitIndexByDocuments<Document>(processor.GetDocuments());
            }

            var responseOfSearchQuery = processor.DoProcessOfSearch(input, client, "documents");
            return responseOfSearchQuery.Documents.OrderByDescending(s => s.Id).Select(d =>d.Name);

        }
    }
}