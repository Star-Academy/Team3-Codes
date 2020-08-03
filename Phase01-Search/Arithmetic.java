
import java.util.ArrayList;
import java.util.HashMap;

public class Arithmetic {

    public static ArrayList<Integer> and(ArrayList<Integer> arr1, ArrayList<Integer> arr2) {
        if (arr1.size() == 0 || arr2.size() == 0)
            return arr1.size() == 0 ? arr2 : arr1;
        ArrayList<Integer> temp = new ArrayList<>(arr1);
        temp.retainAll(arr2);
        return temp;
    }

    public static ArrayList<Integer> or(ArrayList<Integer> arr1, ArrayList<Integer> arr2) {
        ArrayList<Integer> temp = new ArrayList<>(arr1);
        for (Integer integer : arr2)
            if (!temp.contains(integer))
                temp.add(integer);
        return temp;
    }

    public static ArrayList<Integer> subtract(ArrayList<Integer> arr1, ArrayList<Integer> arr2) {
        ArrayList<Integer> temp = new ArrayList<>(arr1);
        temp.removeAll(arr2);
        return temp;
    }

    public static ArrayList<Integer> andAll(ArrayList<String> array, HashMap<String, ArrayList<Integer>> tokens) {
        return array.stream().map(a -> tokens.get(a)).reduce((a, b) -> Arithmetic.and(a, b)).orElse(new ArrayList<>());
    }

    public static ArrayList<Integer> orAll(ArrayList<String> array, HashMap<String, ArrayList<Integer>> tokens) {
        return array.stream().map(a -> tokens.get(a)).reduce((a, b) -> Arithmetic.or(a, b)).orElse(new ArrayList<>());
    }

}