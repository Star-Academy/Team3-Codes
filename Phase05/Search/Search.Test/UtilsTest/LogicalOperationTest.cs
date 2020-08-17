using System.Collections.Generic;
using System.Linq;
using Search.Utils;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class LogicalOperationTest
    {
        private Dictionary<string,HashSet<int>> tokens = new Dictionary<string, HashSet<int>>(); 
            


        public void initTokens(){
          tokens["first"] = new HashSet<int>{1, 2, 3, 4, 5, 6};
          tokens["bye"] =  new HashSet<int>{2, 3, 4, 7};
          tokens["world"] = new HashSet<int>{1, 2, 7, 8, 10};
          tokens["sky"] = new HashSet<int>{1,4,6,9,11};
          tokens["phone"] = new HashSet<int>{3,4,8,1,9};
        }

        [Fact]
        public void ApplyOnAllTestForAndOperation(){
          initTokens();

          var words = new List<string>{"world","first"};
          var expectedValue = new HashSet<int> {1,2};

          var operation = new And();
          var actualValue = operation.ApplyOnAll(words ,tokens);

          Assert.Equal(expectedValue , actualValue);


        }

        [Fact]
        public void ApplyOnAllTestForAndOperationWhenOneWordDoesNotExistInTokens(){
         initTokens();

          var words = new List<string>{"hello","bye"};
          var expectedValue = new HashSet<int> {2, 3, 4, 7};

          var operation = new And();
          var actualValue = operation.ApplyOnAll(words ,tokens);

          Assert.Equal(expectedValue , actualValue);

        }

        [Fact]
        public void SimpleApplyOnAllTestForOrOperation(){
          initTokens();

          var words = new List<string>{"sky","phone","bye","five"};
          var expectedValue = new HashSet<int> {1 ,4 ,6 ,9 ,11 ,3 ,8 ,2 ,7 };

          var operation = new Or();
          var actualValue = operation.ApplyOnAll(words ,tokens);

          Assert.Equal(expectedValue , actualValue);


        }

        [Fact]
        public void SecondApplyOnAllTestForOrOperation(){
          initTokens();

          var words = new List<string>{"ok","agreement"};
          var expectedValue = new HashSet<int> {};

          var operation = new And();
          var actualValue = operation.ApplyOnAll(words ,tokens);


        }
   }
}