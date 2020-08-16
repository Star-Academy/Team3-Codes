using System.Collections.Generic;
namespace Search.Utils
{
    public interface IOperation
    {
        HashSet<int> Apply(HashSet<int> list1, HashSet<int> list2);
        
    }
}