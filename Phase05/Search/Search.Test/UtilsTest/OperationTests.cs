using Search.Utils ;
using System.Linq ;
using Xunit;
using System.Collections.Generic;
namespace Search.Test.UtilsTest

{
    public abstract class OperationTests
    {
        protected IOperation Operation ;
        protected List<int> list1 ; 
        protected List<int> list2 ;
        protected List<int> expectedValue ;

        [Fact]
        protected abstract void init();
    
        
        [Fact]
        public void ApplyTest(){
            var actualValue = Operation.Apply<int>(list1,list2);
            Assert.Equal<int>(expectedValue,actualValue);

        }
    }
}