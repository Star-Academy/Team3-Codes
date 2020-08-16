using System.Collections.Generic;
using  Search.Utils ;

namespace Search.Test.UtilsTest
{
    public class SubtractTests : OperationTests
    {
        protected override void init()
        {
            Operation = new Subtract();

            set1 = new HashSet<int>{8,3,4,5,1,7};
            set2 = new HashSet<int>{2,9,6,3,4};
            expectedValue = new HashSet<int>{8,5,1,7};

            set3 = new HashSet<int>{};
            set4 = new HashSet<int>{5,11,7,6,3,2,8};
            expectedValue2 = new HashSet<int> {};
        }
    }
}