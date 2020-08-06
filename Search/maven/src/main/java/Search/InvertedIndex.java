package Search;

import java.util.ArrayList;
import java.util.HashMap;

public class InvertedIndex {
    private HashMap<String, ArrayList<Integer>> dictMap;

    public InvertedIndex(HashMap<String, ArrayList<Integer>> dictMap) {
        this.dictMap = dictMap;
    }

    public void makeChanges(String newDocument, int documentID) {
        String fullToken = newDocument.toLowerCase();
        String[] tokens = fullToken.split(" ");
        for (String str : tokens) {
            if (!dictMap.containsKey(str))
                dictMap.put(str, new ArrayList<>());

            if (!dictMap.get(str).contains(documentID))
                dictMap.get(str).add(documentID);
        }
    }
}