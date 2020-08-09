package Search;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;

import org.junit.Test;

public class ProcessorTest {

    @Test
    public void processTest() {
        Processor processor = new Processor();
        int numberOfDocs = App.fillTheMap(processor.getTokens());
        ArrayList<Integer> expectedResult = new ArrayList<>(
                Arrays.asList(1, 124, 177, 346, 484, 581, 595, 597, 602, 611, 620, 713, 745, 906, 951));
        ArrayList<Integer> actualResult = processor.process("as i +happen", numberOfDocs);
        for (Integer integer : expectedResult)
            System.out.print(integer + " ");
        assertEquals(expectedResult, actualResult);
    }

}