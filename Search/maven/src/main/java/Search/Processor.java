package Search;
import java.util.ArrayList;
import java.util.HashMap;


public class Processor {
    private HashMap<String, ArrayList<Integer>> tokens;
    private final Reader reader;

    public Processor(Reader reader) {
        this.tokens = new HashMap<>();
        this.reader = reader;
    }

    public HashMap<String, ArrayList<Integer>> getTokens() {
        return this.tokens;
    }

    public int fillTheMap() {
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        int i = 0;
        while (reader.hasNext()) {
            invertedIndex.updateTheMap(reader.next(), i);
            i++;
        }
        return i; // return number of documents
    }

    public ArrayList<Integer> process(String input, int numberOfDocs) {

        ArrayList<String> wordsWithPlusSign = RegexOperator.assortTheWords(input, RegexOperator.PLUS_REGEX, 2);
        ArrayList<String> wordsWithMinusSign = RegexOperator.assortTheWords(input, RegexOperator.MINUS_REGEX, 2);
        ArrayList<String> noneSignWords = RegexOperator.assortTheWords(input, RegexOperator.NONE_SIGN_REGEX, 1);

        ArrayList<Integer> beforeMinus = Arithmetic.and(Arithmetic.andAll(noneSignWords, tokens),
                Arithmetic.orAll(wordsWithPlusSign, tokens));

        // It is for when user input does not have any none sign words or with "+" sign
        // like : "-I -book"
        if (noneSignWords.isEmpty() && wordsWithPlusSign.isEmpty()){}
            for (int i = 0; i < numberOfDocs; i++)
                beforeMinus.add(i);

        return Arithmetic.subtract(beforeMinus, Arithmetic.orAll(wordsWithMinusSign, tokens));

    }

}