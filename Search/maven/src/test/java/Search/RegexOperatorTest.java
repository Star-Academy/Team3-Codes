package Search;

import org.junit.Test;
import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;

public class RegexOperatorTest {
    
    RegexOperator regexOperator = new RegexOperator();

    
    @Test
    public void assortTheWordsTest(){

        String input = "It +is a +great -day +to -live ";
        String regex = "(\\+)(\\w*)" ; 

        ArrayList<String> actual = RegexOperator.assortTheWords(input, regex, 2);
        ArrayList<String> expected = new ArrayList <>(Arrays.asList("is", "great", "to"));

        assertEquals(expected, actual);
        
       
    }
    
}