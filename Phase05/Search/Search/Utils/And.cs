using System.Collections.Generic;
namespace Search.Utils
{
    public class And : LogicalOperation
    {

        public override HashSet<int> Apply(HashSet<int> list1, HashSet<int> list2)
        {
            HashSet<int> temp = new HashSet<int>(list1);
            temp.IntersectWith(list2);
            return temp ;
        }

    }
}