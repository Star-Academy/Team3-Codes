using System.Collections.Generic;
using System.Linq;
using  Search.Utils ;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class OrTests 
    {
        public Dictionary<string, List<int>> tokens = new Dictionary<string, List<int>>();
        protected List<int>  list1 = new List<int>{5,8,7,11,13,17,1};
        protected List<int>  list2 = new List<int>{1,8,3,4,2};
        protected List<int> expectedValue = new List<int> {5,8,7,11,13,17,1,3,4,2};
        List<string> array = new string[]{"world","bye" }.ToList();
        public OrTests(){
          tokens["first"] = new List<int>{1, 2, 3, 4, 5, 6};
          tokens["bye"] =  new List<int>{2, 3, 4, 7};
          tokens["world"] = new List<int>{1, 2, 7, 8, 10};
        }     
        
        [Fact]
        public void ApplyTest(){
            Or or = new Or();
            var actualValue = or.Apply(list1,list2);
            Assert.Equal(expectedValue,actualValue);

        }  

        [Fact]
        public void ApplyOnAllTest(){
            Or or = new Or();
            List<int> actualResult = new List<int>{1, 2, 7, 8, 10, 3, 4};
            List<int> expectedResult = or.ApplyOnAll(array, tokens);
            Assert.Equal(actualResult, expectedResult);
        }
    }
}