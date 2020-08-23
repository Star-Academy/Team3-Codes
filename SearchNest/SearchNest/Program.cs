using System;
using Nest;
using SearchNest.Utils;
using SearchNest.Utils.Nest;
using SearchNest.Utils.Reader;

namespace SearchNest
{
    class Program
    {
        static string path = "Resources";
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            connectionSettings.EnableDebugMode();
            var client = new ElasticClient(connectionSettings);
            // var response = client.Ping();
            var indexHandler = new IndexHandler("documents", client);
            // indexHandler.CreateMapping();
            var reader = new FileReader(path);
            var processor = new Processor(reader);
            // processor.SerializeDocuments();
            // indexHandler.BulkDocs(processor.GetDocuments());
            var response = processor.Process("as i +happen", client, "documents");
        }
    }
}
