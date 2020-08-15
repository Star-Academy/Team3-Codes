using System.Collections.Generic;
using System.Linq;
namespace Search.Model
{
    public class InvertedIndex
    {
        private Dictionary<string, List<int>> dictMap;

        public InvertedIndex(Dictionary<string, List<int>> dictMap)
        {
            this.dictMap = dictMap;
        }

        public void updateTheMap(string docContent, int docID)
        {

            var fullToken = docContent.ToLower();
            var tokensOfThisDoc = fullToken.Split(' ');

            foreach (var str in tokensOfThisDoc)
            {
                if (!dictMap.ContainsKey(str))
                    dictMap[str] = new List<int>();

                if (!dictMap[str].Contains(docID))
                    dictMap[str].Add(docID);
            }
        }

    }
}