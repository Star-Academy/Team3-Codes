using System;
using Nest;
using SearchNest.Utils;
using SearchNest.Utils.Nest;
using SearchNest.Utils.Reader;
using SearchNest.View;

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

            IResponse response = client.Ping();
            if (client.Ping().IsValid)
            {
                var indexHandler = new IndexHandler("documents", client);
                // indexHandler.CreateMapping();
                var processor = new Processor(new FileReader(path));
                processor.SerializeDocuments();
                // indexHandler.BulkDocs(processor.GetDocuments());
                Console.WriteLine("Please enter the sentence you wish to search : ");
                var responseOfSearchQuery = processor.DoProcess(Console.ReadLine(), client, "documents");
                if (responseOfSearchQuery.IsValid)
                    ConsolePrinter.PrintNameOfSuitableDocs(responseOfSearchQuery);
                else
                    ResponseValidator.HandleException(responseOfSearchQuery);
            }
            else ResponseValidator.HandleException(response);

        }
    }
}
