using System.Collections.Generic;
namespace Search.Model
{
    public class InvertedIndex
    {
        private Dictionary<string, HashSet<int>> dictMap;

        public InvertedIndex(Dictionary<string, HashSet<int>> dictMap)
        {
            this.dictMap = dictMap;
        }

        public void UpdateTheMap(string docContent, int docID)
        {

            var fullToken = docContent.ToLower();
            var tokensOfThisDoc = fullToken.Split(' ');

            foreach (var str in tokensOfThisDoc)
            {
                if (!dictMap.ContainsKey(str))
                    dictMap[str] = new HashSet<int>();

                if (!dictMap[str].Contains(docID))
                    dictMap[str].Add(docID);
            }
        }

    }
}