import java.util.ArrayList;

public class Arithmetic {

    public static ArrayList<Integer> and(ArrayList<Integer> arr1, ArrayList<Integer> arr2) {
        ArrayList<Integer> temp = new ArrayList<Integer>(arr1);
        temp.retainAll(arr2);
        return temp;
    }

    public static ArrayList<Integer> or(ArrayList<Integer> arr1, ArrayList<Integer> arr2) {
        ArrayList<Integer> temp = new ArrayList<Integer>(arr1);
        for (Integer integer : arr2) {
            if (!temp.contains(integer)) {
                temp.add(integer);
            }
        }
        return temp;
    }

    public static ArrayList<Integer> subtract(ArrayList<Integer> arr1, ArrayList<Integer> arr2) {
        ArrayList<Integer> temp = new ArrayList<Integer>(arr1);
        temp.removeAll(arr2);
        return temp;
    }
}