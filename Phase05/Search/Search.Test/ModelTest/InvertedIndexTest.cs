using System.Collections.Generic;
using Search.Model;
using Xunit;

namespace Search.Test.ModelTest
{
    public class InvertedIndexTest
    {
        private static Dictionary<string, HashSet<int>> mapOfTheWords;


        [Fact]
        public void InitMap()
        {

            mapOfTheWords = new Dictionary<string, HashSet<int>>
            {
                { "sky", new HashSet<int>{2} },
                { "sunset",new HashSet<int>{1,3} },
                { "tree", new HashSet<int>{5} }
            };
        }

        [Fact]
        public void UpdateTheMapTest()
        {

            var str = "The sky , at sunset , looked like a carnivorous flower .";
            InvertedIndex invertedIndex = new InvertedIndex(mapOfTheWords);
            invertedIndex.UpdateTheMap(str, 1);
            
            Assert.Equal(mapOfTheWords["sky"].Count, 2);
            Assert.Equal(mapOfTheWords["sunset"].Count, 2);
            Assert.Equal(mapOfTheWords["tree"].Count, 1);
            Assert.Equal(mapOfTheWords["flower"].Count, 1);



        }


    }
}