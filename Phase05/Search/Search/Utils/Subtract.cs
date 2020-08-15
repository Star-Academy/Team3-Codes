using System.Collections.Generic;

namespace Search.Utils
{
    public class Subtract : IOperation
    {
        public List<T> Apply<T>(List<T> list1, List<T> list2)
        {
            return list1.FindAll(a => !list2.Contains(a));
        }
    }
}