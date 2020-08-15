using System.Collections.Generic;
using System.Linq ;
namespace Search.Utils
{
    public class Or : IOperation
    {
        public List<int> Apply(List<int> list1, List<int> list2)
        {
            return list1.Concat(list2.FindAll(a => !list1.Contains(a))).ToList();
            
        }
        public List<int> ApplyOnAll(List<string> words, Dictionary<string, List<int>> tokens)
        {
            return words.Where(a => tokens.ContainsKey(a)).Select(w => tokens[w])
            .Aggregate((a,b)=>Apply(a,b));

        }
    }
}