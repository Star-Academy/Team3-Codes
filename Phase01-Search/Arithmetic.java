
import java.util.ArrayList;
import java.util.HashMap;

public class Arithmetic {

    public static ArrayList<Integer> doOperation(ArrayList<Integer> arr1, ArrayList<Integer> arr2,
            Operation operation) {
        ArrayList<Integer> temp = new ArrayList<>(arr1);

        switch (operation) {
            case OR:
                for (Integer integer : arr2)
                    if (!temp.contains(integer))
                        temp.add(integer);
                break;
            case AND:
                if (arr1.size() == 0 || arr2.size() == 0)
                    temp = arr1.size() == 0 ? arr2 : arr1;
                temp.retainAll(arr2);
                break;
            case SUBTRACT:
                temp.removeAll(arr2);
                break;
        }

        return temp;
    }

    public static ArrayList<Integer> andAll(ArrayList<String> array, HashMap<String, ArrayList<Integer>> tokens) {
        return array.stream().map(a -> tokens.get(a)).reduce((a, b) -> Arithmetic.doOperation(a, b, Operation.AND))
                .orElse(new ArrayList<>());
    }

    public static ArrayList<Integer> orAll(ArrayList<String> array, HashMap<String, ArrayList<Integer>> tokens) {
        return array.stream().map(a -> tokens.get(a)).reduce((a, b) -> Arithmetic.doOperation(a, b, Operation.OR))
                .orElse(new ArrayList<>());
    }

}
