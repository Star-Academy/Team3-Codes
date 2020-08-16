using System.Collections.Generic;
using System.Linq;

namespace Search.Utils
{
    public class And : LogicalOperation
    {

        public override HashSet<int> Apply(HashSet<int> set1, HashSet<int> set2)
        {
           return set1.Intersect(set2).ToHashSet();
        }

    }
}