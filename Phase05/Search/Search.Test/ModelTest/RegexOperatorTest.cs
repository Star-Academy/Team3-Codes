using Xunit;
using Search.Model;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Search.Test.ModelTest
{
    public class RegexOperatorTest
    {
        [Fact]
        public void AssortTheWordsTest()
        {
            string input = "It +is a +great -day +to -live ";
            Regex regex = new Regex("(\\+)(\\w*)");

            List<string> actual = RegexOperator.AssortTheWords(input, regex, 2);
            List<string> expected =  new string[]{ "is", "great", "to" }.ToList();
            Assert.Equal(actual,expected);

        }
    }
}