using System.Collections.Generic;
namespace Search.Utils
{
    public class Subtract : IOperation 
    {
        public HashSet<int> Apply(HashSet<int> set1, HashSet<int> set2)
        {
            var temp = new HashSet<int>(set1);
            temp.RemoveWhere(a => set2.Contains(a));
            return temp ;
        }

    }
}