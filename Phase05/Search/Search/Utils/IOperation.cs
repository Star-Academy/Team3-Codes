using System.Collections.Generic;
using System.Linq;
namespace Search.Utils
{
    public interface IOperation
    {
        List<int> Apply(List<int> list1, List<int> list2);
        
    }
}