package Search;

import static org.junit.Assert.assertArrayEquals;
import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;
import java.util.ArrayList;
import org.junit.Before;
import org.junit.Test;


public class ProcessorTest {

    private String[] docs ;
    private Processor processor ;


   
    
    @Before
    public void init() {

         docs = new String[3];
         docs[0] = "The sky , at sunset , looked like a carnivorous flower ." ;
         docs[1] = "Let the sun stay beautiful in the blue sky ." ;
         docs[2] = "Trees are poems that the earth writes upon the sky ." ;

         FileReader fileReader = mock(FileReader.class);
         when(fileReader.hasNext()).thenReturn(true,true,true,false);
         when(fileReader.next()).thenReturn(docs[0],docs[1],docs[2]);

         processor  =  new Processor(fileReader);

    }
    
    @Test
    public void fillTheMapTest() {
        
        int numberOfDocs = processor.fillTheMap();
        assertEquals(3, numberOfDocs);
   

    }

    @Test
    public void processTest1(){

        fillTheMapTest();
        ArrayList<Integer> actualValue = processor.process("sky -blue -flower", 3);
        Integer[] expectedValue = {2};

        assertArrayEquals(expectedValue, actualValue.toArray());

    }

    @Test
    public void processTest2(){

        fillTheMapTest();
        ArrayList<Integer> actualValue = processor.process("+flower +trees", 3);
        Integer[] expectedValue = {0,2};

        assertArrayEquals(expectedValue, actualValue.toArray());

    }
    
    @Test
    public void processTest3(){

        fillTheMapTest();
        ArrayList<Integer> actualValue = processor.process("-poems -earth -sun", 3);
        Integer[] expectedValue = {1,2};

        assertArrayEquals(expectedValue, actualValue.toArray());

    }



    }
   
