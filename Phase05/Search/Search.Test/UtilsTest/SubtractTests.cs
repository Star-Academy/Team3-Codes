using System.Collections.Generic;
using  Search.Utils ;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class SubtractTests : OperationTests
    {
        protected override void init()
        {
            Operation = new Subtract();

            list1 = new List<int>{8,3,4,5,1,7};
            list2 = new List<int>{2,9,6,3,4};
            expectedValue = new List<int> {8,5,1,7};

            list3 = new List<int>{};
            list4 = new List<int>{5,11,7,6,3,2,8};
            expectedValue2 = new List<int> {};
        }
    }
}