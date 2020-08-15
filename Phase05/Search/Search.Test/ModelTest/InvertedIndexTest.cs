using System.Collections.Generic;
using Search.Model;
using Xunit;

namespace Search.Test.ModelTest
{
    public class InvertedIndexTest
    {
        private static Dictionary<string, List<int>> mapOfTheWords;


        [Fact]
        public void initMap()
        {

            mapOfTheWords = new Dictionary<string, List<int>>()
            {
                { "sky", new List<int>{2} },
                { "sunset",new List<int>{1,3} },
                { "tree", new List<int>{5} }
            };
        }

        [Fact]
        public void updateTheMapTest()
        {

            string str = "The sky , at sunset , looked like a carnivorous flower .";
            InvertedIndex invertedIndex = new InvertedIndex(mapOfTheWords);
            invertedIndex.updateTheMap(str, 1);
            Assert.Equal(mapOfTheWords["sky"].Count, 2);
            Assert.Equal(mapOfTheWords["sunset"].Count, 2);
            Assert.Equal(mapOfTheWords["tree"].Count, 1);
            Assert.Equal(mapOfTheWords["flower"].Count, 1);



        }


    }
}