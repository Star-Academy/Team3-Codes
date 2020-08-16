using System.Collections.Generic;
using System.Linq ;
namespace Search.Utils
{
    public class Or : LogicalOperation
    {
        public override HashSet<int> Apply(HashSet<int> list1, HashSet<int> list2)
        {
            HashSet<int> temp = new HashSet<int>(list1);
            temp.UnionWith(list2);
            return temp ;
            
        }
    }
}