using System;
using System.Collections.Generic;
using Moq;
using Search.Model;
using Search.Utils;
using Xunit;

namespace Search.Test.UtilsTest
{
    public class ProcessorTest
    {

        private string[] docs;
        private Processor Processor;


        public void Init()
        {

            docs = new String[3];
            docs[0] = "The sky , at sunset , looked like a carnivorous flower .";
            docs[1] = "Let the sun stay beautiful in the blue sky .";
            docs[2] = "Trees are poems that the earth writes upon the sky .";

            var enumerator = docs.GetEnumerator();

            var fileReader = new Mock<IReader>();

            fileReader.Setup(x => x.MoveNext()).Returns(enumerator.MoveNext);
            fileReader.Setup(x => x.Current()).Returns(() => (string)enumerator.Current);

            Processor = new Processor(fileReader.Object);

        }

        [Fact]
        public void FillTheMapTest()
        {

            Init();
            int numberOfDocs = Processor.FillTheMap();
            Assert.Equal(3, numberOfDocs);


        }

        [Fact]
        public void processTest1()
        {

            FillTheMapTest();
            var actualValue = Processor.Process("sky -blue -flower", 3);
            var expectedValue = new HashSet<int> { 2 };

            Assert.Equal(expectedValue, actualValue);

        }

        [Fact]
        public void processTest2()
        {

            FillTheMapTest();
            var actualValue = Processor.Process("+flower +trees", 3);
            var expectedValue = new HashSet<int> { 0, 2 };

            Assert.Equal(expectedValue, actualValue);


        }

        [Fact]
        public void processTest3()
        {
            FillTheMapTest();
            var actualValue = Processor.Process("-poems -earth -sun", 3);
            var expectedValue = new HashSet<int> { 0 };

            Assert.Equal(expectedValue, actualValue);

        }

    }

}
