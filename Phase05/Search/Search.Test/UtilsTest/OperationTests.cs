using Search.Utils ;
using Xunit;
using System.Collections.Generic;
namespace Search.Test.UtilsTest

{
     public abstract class OperationTests
    {
        protected IOperation Operation ;
        protected HashSet<int> list1 ; 
        protected HashSet<int> list2 ;
        protected HashSet<int> list3 ; 
        protected HashSet<int> list4 ;
        protected HashSet<int> expectedValue ;
        protected HashSet<int> expectedValue2 ;

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