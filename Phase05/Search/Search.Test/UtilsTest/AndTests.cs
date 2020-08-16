using System.Linq ;
using System.Collections.Generic;
using  Search.Utils ;
using Xunit;

namespace Search.Test.UtilsTest
{

        public class AndTest : OperationTests
        {

            protected override void init()
            {
                Operation = new And();
                
                list1 = new List<int>{3,4,5,1,8};
                list2 = new List<int>{5,11,7,6,3,2,8};
                expectedValue = new List<int> {3,5,8};
                
                list3 = new List<int>{};
                list4 = new List<int>{5,11,7,6,3,2,8};
                expectedValue = new List<int> {5,11,7,6,3,2,8};
            }
        }

}