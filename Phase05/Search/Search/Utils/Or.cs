using System.Collections.Generic;
using System.Linq ;
namespace Search.Utils
{
    public class Or : LogicalOperation
    {
        public override List<int> Apply(List<int> list1, List<int> list2)
        {
            return list1.Concat(list2.FindAll(a => !list1.Contains(a))).ToList();
            
        }
    }
}