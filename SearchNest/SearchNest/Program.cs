using System;
using System.Collections.Generic;
using System.Linq;
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

            var indexHandler = new IndexHandler("documents", client);
            // indexHandler.CreateMapping();

            var processor = new Processor(new FileReader(path));
            processor.SerializeDocuments();
            // indexHandler.BulkDocs(processor.GetDocuments());


            var response = processor.doProcess(Console.ReadLine(), client, "documents");
            ConsolePrinter.PrintNameOfSuitableDocs(response);

        }
    }
}
