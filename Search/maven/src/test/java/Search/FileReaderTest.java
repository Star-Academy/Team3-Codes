package Search;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class FileReaderTest {
    private String testPath = "src\\test\\java\\Search\\Reader.txt";

    @Test
    public void getFileContentsTest() {
        String actualResult = FileReader.getFileContents(testPath);
        String expectedResult = "Team3-Codes kimia noorbakhsh, mahla sharifi";
        assertEquals(expectedResult, actualResult);
    }
}