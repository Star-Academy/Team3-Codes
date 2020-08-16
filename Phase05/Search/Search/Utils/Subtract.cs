using System.Collections.Generic;
namespace Search.Utils
{
    public class Subtract : IOperation 
    {
        public HashSet<int> Apply(HashSet<int> list1, HashSet<int> list2)
        {
            HashSet<int> temp = new HashSet<int>(list1);
            temp.RemoveWhere(a => list2.Contains(a));
            return temp ;
        }

    }
}