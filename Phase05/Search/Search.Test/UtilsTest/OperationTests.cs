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
        protected List<int> list3 ; 
        protected List<int> list4 ;
        protected List<int> expectedValue ;
        protected List<int> expectedValue2 ;

        [Fact]
        protected abstract void init();
    
        
        [Fact]
        public void FirstApplyTest(){
            init();
            var actualValue = Operation.Apply(list1,list2);
            Assert.Equal(expectedValue,actualValue);

        }
        
        [Fact]
        public void SecondApplyTest(){
            init();
            var actualValue2 = Operation.Apply(list3,list4);
            Assert.Equal<int>(expectedValue2,actualValue2);

        }
     }
}