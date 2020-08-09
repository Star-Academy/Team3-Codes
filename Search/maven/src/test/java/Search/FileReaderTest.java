package Search;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class FileReaderTest {
    private String testPath = "resources\\TestDocs\\doc1.txt";

    @Test
    public void getFileContentsTest() {
        String actualResult = FileReader.getFileContents(testPath);
        String expectedResult = "The sky , at sunset , looked like a carnivorous flower .";
        assertEquals(expectedResult, actualResult);
    }
}