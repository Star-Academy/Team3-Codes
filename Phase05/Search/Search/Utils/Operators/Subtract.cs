using System.Collections.Generic;
using System.Linq;

namespace Search.Utils
{
    public class Subtract : IOperation 
    {
        public HashSet<int> Apply(HashSet<int> set1, HashSet<int> set2)
        {
            return set1.Except(set2).ToHashSet() ;
        }

    }
}