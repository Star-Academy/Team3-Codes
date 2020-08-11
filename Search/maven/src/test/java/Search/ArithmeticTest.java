package Search;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

import org.junit.Before;
import org.junit.Test;

public class ArithmeticTest {
    private HashMap<String, ArrayList<Integer>> tokens;
    private ArrayList<String> array;    // to test andAll and orAll
    private ArrayList<Integer> first = new ArrayList<>(Arrays.asList(1, 2, 3, 4, 5, 6));
    private ArrayList<Integer> second = new ArrayList<>(Arrays.asList(2, 3, 4, 7));
    private ArrayList<Integer> third = new ArrayList<>(Arrays.asList(1, 2, 7, 8, 10));

    @Before
    public void preperation() {
        tokens = new HashMap<>();
        array = new ArrayList<>();
        tokens.put("hello", first);
        tokens.put("bye", second);
        tokens.put("world", third);
        array.add("hello");
        array.add("world");
    }

    @Test
    public void andTest() {
        ArrayList<Integer> actualResult = new ArrayList<>(Arrays.asList(2, 3, 4));
        ArrayList<Integer> expectedResult = Arithmetic.and(first, second);
        assertEquals(actualResult, expectedResult);
    }

    @Test
    public void orTest() {
        ArrayList<Integer> actualResult = new ArrayList<>(Arrays.asList(1, 2, 3, 4, 5, 6, 7));
        ArrayList<Integer> expectedResult = Arithmetic.or(first, second);
        assertEquals(actualResult, expectedResult);
    }

    @Test
    public void subtractTest() {
        ArrayList<Integer> actualResult = new ArrayList<>(Arrays.asList(1, 5, 6));
        ArrayList<Integer> expectedResult = Arithmetic.subtract(first, second);
        assertEquals(actualResult, expectedResult);
    }

    @Test
    public void andAllTest() {
        ArrayList<Integer> actualResult = new ArrayList<>(Arrays.asList(1, 2));
        ArrayList<Integer> expectedResult = Arithmetic.andAll(array, tokens);
        assertEquals(actualResult, expectedResult);
    }

    @Test
    public void orAllTest() {
        ArrayList<Integer> actualResult = new ArrayList<>(Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 10));
        ArrayList<Integer> expectedResult = Arithmetic.orAll(array, tokens);
        assertEquals(actualResult, expectedResult);
    }

}