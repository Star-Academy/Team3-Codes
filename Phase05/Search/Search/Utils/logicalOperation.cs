using System;
using System.Collections.Generic;
using System.Linq;
namespace Search.Utils
{
    public abstract class LogicalOperation : IOperation
    {
        public abstract List<int> Apply(List<int> list1, List<int> list2);
        

        public List<int> ApplyOnAll(List<string> words, Dictionary<string, List<int>> tokens)
        {
            if(words.Where(w => tokens.ContainsKey(w)).FirstOrDefault() == null)
                return new List<int>();

            return words.Where(w => tokens.ContainsKey(w))
                .Select(w => tokens[w])
                .Aggregate((a, b) => Apply(a, b));
             
           
        }
    }
}