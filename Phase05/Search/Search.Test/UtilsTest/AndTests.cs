using System.Linq ;
using System.Collections.Generic;
using  Search.Utils ;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class AndTests 
    {     
        public Dictionary<string, List<int>> tokens = new Dictionary<string, List<int>>(); 
        private List<int>  list1 = new List<int>{3,4,5,1,8};
        private List<int>  list2 = new List<int>{5,11,7,6,3,2,8};
        private List<int> expectedValue = new List<int> {3,5,8};   
        List<string> array = new string[]{"world"}.ToList();
        public AndTests(){
          tokens["first"] = new List<int>{1, 2, 3, 4, 5, 6};
          tokens["bye"] =  new List<int>{2, 3, 4, 7};
          tokens["world"] = new List<int>{1, 2, 7, 8, 10};
        } 

        
        [Fact]
        public void ApplyTest(){
            And and = new And();
            var actualValue = and.Apply(list1,list2);
            Assert.Equal(expectedValue,actualValue);

        }

        [Fact]
        public void ApplyOnAllTest(){
            And and = new And();
            List<int> actualResult = new List<int>{1,2,7,8,10};
            List<int> expectedResult = and.ApplyOnAll(array, tokens);
            Assert.Equal(actualResult, expectedResult);
        }
    }

}