using System;
using System.Collections.Generic;
using Nest;
using NestTest.Model;
namespace NestTest
{
    class Program
    {
        private static string pathOfPeopleJson = "Resources\\people.json";
        static void Main(string[] args)
        {
            var uri = new Uri ("http://localhost:9200");
            var connectionSettings = new ConnectionSettings (uri);
            connectionSettings.EnableDebugMode();
            var client = new ElasticClient (connectionSettings);
            var response = client.Ping();
            // var reader = new JsonReader();
            // var people = reader.Read(pathOfPeopleJson);
            // Console.Write(IndexHandler.CreateMapping(client));
            // BulkPeople(people, "people", client);
            var queryResponse = Query.FuzzyQuerySample(client,"people");
        }

        public static void BulkPeople(List<Person> people, string index, ElasticClient client)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var person in people)
            {
                bulkDescriptor.Index<Person>(x => x
                    .Index(index)
                    .Document(person)
                );
            }
            client.Bulk(bulkDescriptor);
        }
    }
}
