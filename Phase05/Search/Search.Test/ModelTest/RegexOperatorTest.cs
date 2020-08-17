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
            var input = "It +is a +great -day +to -live ";
            var regex = new Regex("^(\\w*)");

            var actual = RegexOperator.AssortTheWords(input, regex, 1);
            var expected =  new string[]{ "It" }.ToList();

            Assert.Equal(actual,expected);

        }
    }
}