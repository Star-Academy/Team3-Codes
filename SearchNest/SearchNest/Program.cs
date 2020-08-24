using System;
using System.Collections.Generic;
using System.Linq;
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
            
            string wordsWithPlusSign = "happen old";
            string wordsWithMinusSign =  "recently" ;
            string noneSignWords = "as i" ;

            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            connectionSettings.EnableDebugMode();
            var client = new ElasticClient(connectionSettings);
            //    var response = client.Ping();
            var indexHandler = new IndexHandler("documents", client);
             indexHandler.CreateMapping();
            var reader = new FileReader(path);
            var processor = new Processor(reader);
        //      processor.SerializeDocuments();
        //    indexHandler.BulkDocs(processor.GetDocuments());
             SearchQuery s = new SearchQuery(client,"documents");
             var response = s.SearchForAllWords(wordsWithPlusSign,wordsWithMinusSign,noneSignWords);
            var Docss = response.Documents.OrderByDescending(s => s.Id).ToList();
            foreach(var doc in Docss){
                Console.Write(doc.Id+" ");
            }

        }
    }
}
