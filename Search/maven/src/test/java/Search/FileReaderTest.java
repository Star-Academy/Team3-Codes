package Search;

import static org.junit.Assert.assertEquals;

import java.io.IOException;

import org.junit.Test;

public class FileReaderTest {
    private String testPath = "maven\\src\\test\\resources\\TestDocs";

    @Test
    public void hasNextTest() throws IOException {
            FileReader reader = new FileReader(testPath);
            assertEquals(reader.hasNext(), true);
    }

    @Test
    public void NextTest() throws IOException {
        
            FileReader reader = new FileReader(testPath);
            String actual = reader.next();
            String expected = "The sky , at sunset , looked like a carnivorous flower .";
            assertEquals(expected, actual);
    
    }
}