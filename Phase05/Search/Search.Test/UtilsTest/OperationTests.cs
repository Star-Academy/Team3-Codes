using Search.Utils ;
using Xunit;
using System.Collections.Generic;
namespace Search.Test.UtilsTest

{
     public abstract class OperationTests
    {
        protected IOperation Operation ;
        protected HashSet<int> set1 ; 
        protected HashSet<int> set2 ;
        protected HashSet<int> set3 ; 
        protected HashSet<int> set4 ;
        protected HashSet<int> expectedValue ;
        protected HashSet<int> expectedValue2 ;

        protected abstract void init();
    
        
        [Fact]
        public void FirstApplyTest(){
            init();
            var actualValue = Operation.Apply(set1,set2);
            Assert.Equal(expectedValue,actualValue);

        }

        [Fact]
        public void SecondApplyTest(){
            init();
            var actualValue2 = Operation.Apply(set3,set4);
            Assert.Equal<int>(expectedValue2,actualValue2);

        }
     }
}