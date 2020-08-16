
using System.Collections.Generic;
using System.Linq;
namespace Search.Utils
{
    public abstract class LogicalOperation : IOperation
    {
        public abstract HashSet<int> Apply(HashSet<int> list1, HashSet<int> list2);
        

        public HashSet<int> ApplyOnAll(List<string> words, Dictionary<string, HashSet<int>> tokens)
        {
            if(words.Where(w => tokens.ContainsKey(w)).FirstOrDefault() == null)
                return new HashSet<int>();

            return words.Where(w => tokens.ContainsKey(w))
                .Select(w => tokens[w])
                .Aggregate((a, b) => Apply(a, b));
             
           
        }
    }
}