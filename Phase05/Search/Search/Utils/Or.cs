using System.Collections.Generic;
using System.Linq ;
namespace Search.Utils
{
    public class Or : IOperation
    {
        public List<T> Apply<T>(List<T> list1, List<T> list2)
        {
            return list1.Concat(list2).ToList();
        }
        //  public List<T> ApplyOnAll<T>(List<string> words, Dictionary<string, List<T>> tokens)
        // {
        //     return words.Select(w => tokens[w])
        //     .Aggregate((a,b)=>Apply(a,b));

        // }
    }
}