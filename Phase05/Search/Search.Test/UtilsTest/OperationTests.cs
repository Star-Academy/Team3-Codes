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

        [Fact]
        protected abstract void Init();
    
        
        [Fact]
        public void FirstApplyTest(){
            Init();
            var actualValue = Operation.Apply(set1,set2);
            Assert.Equal(expectedValue,actualValue);

        }

        [Fact]
        public void SecondApplyTest(){
            Init();
            var actualValue2 = Operation.Apply(set3,set4);
            Assert.Equal<int>(expectedValue2,actualValue2);

        }
     }
}