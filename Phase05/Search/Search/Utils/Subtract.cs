using System.Collections.Generic;

namespace Search.Utils
{
    public class Subtract : IOperation 
    {
        public List<int> Apply(List<int> list1, List<int> list2)
        {
            return list1.FindAll(a => !list2.Contains(a));
        }

    }
}