using System.Collections.Generic;
using System.Linq ;
namespace Search.Utils
{
    public class Or : LogicalOperation
    {
        public override HashSet<int> Apply(HashSet<int> set1, HashSet<int> set2)
        {
            var temp = new HashSet<int>(set1);
            temp.UnionWith(set2);
            return temp ;
            
        }
    }
}