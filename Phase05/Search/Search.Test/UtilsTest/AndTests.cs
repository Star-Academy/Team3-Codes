
using System.Collections.Generic;
using  Search.Utils ;


namespace Search.Test.UtilsTest
{

        public class AndTest : OperationTests
        {

            protected override void init()
            {
                Operation = new And();
                
                list1 = new HashSet<int>{3,4,5,1,8};
                list2 = new HashSet<int>{5,11,7,6,3,2,8};
                expectedValue = new HashSet<int>{3,5,8};
                
                list3 = new HashSet<int>{};
                list4 = new HashSet<int>{5,11,7,6,3,2,8};
                expectedValue2 = new HashSet<int>{};

            }
        }

}