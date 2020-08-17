using Xunit;
using Search.Utils;

namespace Search.Test.UtilsTest
{
    public class FileReaderTest
    {
        private const string TestPath =  "resources";

        [Fact]
        public void MoveNextTest()
        {
            
            FileReader reader = new FileReader(TestPath);
            Assert.Equal(reader.MoveNext(),true);
        }

        [Fact]
        public void CurrentTest()
        {
            var reader = new FileReader(TestPath);
            reader.MoveNext();

            string actual = reader.Current();
            string expected = "The sky , at sunset , looked like a carnivorous flower .";
            
            Assert.Equal(actual,expected);
        }
        
    }
}