using System;
using System.Reflection;
using Search.Model;
using Search.Utils;

namespace ConsoleApp
{
    class Program
    {
        private const string path = "Docs";
        static void Main(string[] args)
        {

            // Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            var reader = new FileReader(path);
            var processor  = new Processor(reader);
            var numberOfDocs = processor.FillTheMap();

            Console.WriteLine("Enter the string of words which you want to search .");

            foreach (var integer in processor.Process(Console.ReadLine(), numberOfDocs))
                Console.Write($"{integer} ");
        }
    }
}
