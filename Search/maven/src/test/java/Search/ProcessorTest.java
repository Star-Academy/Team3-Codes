package Search;

import static org.junit.Assert.assertEquals;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;

import org.junit.Test;

public class ProcessorTest {

    @Test
    public void processTest() throws IOException {

        Processor processor = new Processor(new FileReader("src\\test\\resources\\TestDocs"));
        int numberOfDocs = processor.fillTheMap();


        ArrayList<Integer> actualResult = processor.process("sky -blue", numberOfDocs);

        assertEquals(1,actualResult.size());
        assertEquals((Integer)0,actualResult.get(0));
    }

}