using System;
using System.Linq;
using Nest;
using SearchNest.Model;

namespace SearchNest.View
{
    public class ConsolePrinter
    {
        public static void PrintNameOfSuitableDocs(ISearchResponse<Document> response)
        {
            var docs = response.Documents.OrderByDescending(s => s.Id).ToList();
            foreach (var doc in docs)
            {
                Console.Write(doc.Id + " ");
            }
        }
    }
}