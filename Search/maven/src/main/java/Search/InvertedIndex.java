package Search;

import java.util.ArrayList;
import java.util.HashMap;

public class InvertedIndex {
    private HashMap<String, ArrayList<Integer>> dictMap;

    public InvertedIndex(HashMap<String, ArrayList<Integer>> dictMap) {
        this.dictMap = dictMap;
    }

    public void updateTheMap(String docContent, int docID) {
        String fullToken = docContent.toLowerCase();
        String[] tokens = fullToken.split(" ");
        for (String str : tokens) {
            if (!dictMap.containsKey(str))
                dictMap.put(str, new ArrayList<>());

            if (!dictMap.get(str).contains(docID))
                dictMap.get(str).add(docID);
        }
    }
}