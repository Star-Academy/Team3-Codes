using System.Collections.Generic;
using  Search.Utils ;


namespace Search.Test.UtilsTest
{

        public class AndTest : OperationTests
        {

            protected override void Init()
            {
                Operation = new And();
                
                set1 = new HashSet<int>{3,4,5,1,8};
                set2 = new HashSet<int>{5,11,7,6,3,2,8};
                expectedValue = new HashSet<int>{3,5,8};
                
                set3 = new HashSet<int>{};
                set4 = new HashSet<int>{5,11,7,6,3,2,8};
                expectedValue2 = new HashSet<int>{};

            }
        }

}