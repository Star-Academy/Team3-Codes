package Search;
import org.junit.Test;

import static org.junit.Assert.assertArrayEquals;
import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;


import org.junit.Before;

public class InvertedIndexTest {
    private static HashMap <String, ArrayList<Integer>> mapOfTheWords ;
    Scanner scanner ;

    @Before
    public void initMap(){
        mapOfTheWords = new HashMap<>();
        mapOfTheWords.put("sky",new ArrayList<>(Arrays.asList(2)));
        mapOfTheWords.put("sunset",new ArrayList<>(Arrays.asList(1,3)));
        mapOfTheWords.put("tree",new ArrayList<>(Arrays.asList(5)));
    }
    
    @Test
    public void updateTheMapTest(){
    
        scanner = new Scanner("src\\test\\resources\\TestDocs\\doc1.txt");
      
        InvertedIndex invertedIndex = new InvertedIndex(mapOfTheWords);
        // invertedIndex.updateTheMap(scanner.nextLine(), 1);
        
        // assertArrayEquals(, actuals);
        assertEquals(mapOfTheWords.get("sky").size(), 2);
        // assertEquals(mapOfTheWords.get("sunset").size(),2);
        // assertEquals(mapOfTheWords.get("tree").size(),1);
        assertEquals(mapOfTheWords.size(),3);
        //  assertEquals(mapOfTheWords.get("flower").size(),1);
        
        assertEquals(1, 1);
        
    }
    
}