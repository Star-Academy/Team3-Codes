using System.Collections.Generic;
using  Search.Utils ;

namespace Search.Test.UtilsTest
{
    public class OrTest : OperationTests
    {
      
        protected override void init()
        {
            Operation = new Or();

            list1 = new HashSet<int>{3,4,5,1,8};
            list2 = new HashSet<int>{5,11,7,6,3,2,8};
            expectedValue = new HashSet<int>{3,4,5,1,8,11,7,6,2};

            list3 = new HashSet<int>{};
            list4 = new HashSet<int>{5,11,7,6,3,2,8};
            expectedValue2 = new HashSet<int>{5,11,7,6,3,2,8};

        }   
    }
} 