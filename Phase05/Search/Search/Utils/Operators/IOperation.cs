using System.Collections.Generic;
namespace Search.Utils
{
    public interface IOperation
    {
        HashSet<int> Apply(HashSet<int> set1, HashSet<int> list2);
        
    }
}