import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Test {

    public static ArrayList<Integer> subtract(ArrayList<Integer> arr1, ArrayList<Integer>... arr2) {
        ArrayList<Integer> temp = new ArrayList<Integer>(arr1);
        for (ArrayList<Integer> integers : arr2) {
            temp.removeAll(integers);
        }
        return temp;
    }

    public static void main(String[] args) {
//        Test test = new Test();
//        List<Integer> arr1 = (ArrayList<IArrays.asList(1,4,5,6,7,8,11,17);
//        List<Integer> arr2 = Arrays.asList(1,4,17);
//        List<Integer> arr3 = Arrays.asList(11);
//
//        for (Object o : subtract(arr1 , arr2 , arr3)) {
//            System.out.println(o);
//        }
//    }
    }}
