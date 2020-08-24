
using System;
using Search.Model;
using Search.Utils;

namespace Search
{
    public class Program
    
    {
        private const string path = "Resources";
        public static void Main(string[] args)
        {
            var reader = new FileReader(path);
            var processor  = new Processor(reader);
            var numberOfDocs = processor.FillTheMap();

            Console.WriteLine("Enter the string of words which you want to search .");

            foreach (var integer in processor.Process(Console.ReadLine(), numberOfDocs))
                Console.Write($"{integer} ");
              Console.Write(processor.Process(Console.ReadLine(), numberOfDocs).Count);
        }
    }
};