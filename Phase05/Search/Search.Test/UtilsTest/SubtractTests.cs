using System.Collections.Generic;
using  Search.Utils ;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class SubtractTests 
    {      
        protected List<int>  list1 = new List<int>{3,4,5,1,8};
        protected List<int>  list2 = new List<int>{5,11,7,6,3,2,8};
        protected List<int> expectedValue = new List<int> {4,1};    
        
        [Fact]
        public void ApplyTest(){
            Subtract sub = new Subtract();
            var actualValue = sub.Apply(list1,list2);
            Assert.Equal(expectedValue,actualValue);

        }
    }
}