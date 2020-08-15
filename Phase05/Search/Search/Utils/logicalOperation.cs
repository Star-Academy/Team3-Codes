using System.Collections.Generic;

namespace Search.Utils
{
    public abstract class Ilogical : IOperation
    {
        public List<int> Apply(List<int> list1, List<int> list2)
        {
            throw new System.NotImplementedException();
        }

        public List<int> ApplyOnAll(List<string> words, Dictionary<string, List<int>> tokens)
        {
            throw new System.NotImplementedException();
        }
    }
}