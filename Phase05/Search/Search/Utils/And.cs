using System.Collections.Generic;
namespace Search.Utils
{
    public class And : LogicalOperation
    {

        public override HashSet<int> Apply(HashSet<int> set1, HashSet<int> set2)
        {
            HashSet<int> temp = new HashSet<int>(set1);
            temp.IntersectWith(set2);
            return temp ;
        }

    }
}