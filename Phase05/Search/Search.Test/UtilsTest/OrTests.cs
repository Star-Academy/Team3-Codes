using System.Collections.Generic;
using  Search.Utils ;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class OrTests : OperationTests
    {
        [Fact]
        protected override void init()
        {
             Operation = new Or();
            list1 = new List<int>{3,5,1,8};
            list2 = new List<int>{5,11,7,6,3,2,8};
            expectedValue = new List<int> {3,4,5,1,8,11,7,6,2};
        }
            
        [Fact]
        public void alaki(){
            
        }    
    }
}