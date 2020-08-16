using System;
using System.Linq ;
using Search.Model;
using Search.Utils;

namespace Search
{
    public class Program
    
    {
        public static void Main(string[] args)
        {
            var reader = new FileReader("Resources");
            var processor  = new Processor(reader);
            var numberOfDocs = processor.fillTheMap();
            Console.WriteLine("Enter the string of words which you want to search .");
            foreach (int integer in processor.process(Console.ReadLine(), numberOfDocs))
                Console.Write(integer + " ");
        }
    }
}
