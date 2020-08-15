using System.Collections.Generic;
using  Search.Utils ;
namespace Search.Test.UtilsTest
{
    public class SubtractTests : OperationTests
    {
        protected override void init()
        {
            Operation = new Subtract();
            list1 = new List<int>{3,4,5,1,8};
            list2 = new List<int>{5,11,7,6,3,2,8};
            expectedValue = new List<int> {4,1};
        }
    }
}