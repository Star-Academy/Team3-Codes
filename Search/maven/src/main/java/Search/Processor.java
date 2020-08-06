package Search;

import java.util.ArrayList;
import java.util.HashMap;

public class Processor {
    private HashMap<String, ArrayList<Integer>> tokens;

    public Processor() {
        this.tokens = new HashMap<>();
    }

    public HashMap<String, ArrayList<Integer>> getTokens() {
        return this.tokens;
    }

    public ArrayList<Integer> process(String input, int numberOfDocs) {
        RegexOperator operator = new RegexOperator();
        ArrayList<String> wordsWithPlusSign = operator.assortTheWords(input, RegexOperator.PLUS_REGEX, 2);
        ArrayList<String> wordsWithMinusSign = operator.assortTheWords(input, RegexOperator.MINUS_REGEX, 2);
        ArrayList<String> noneSignWords = operator.assortTheWords(input, RegexOperator.NONE_SIGN_REGEX, 1);

        ArrayList<Integer> beforeMinus = Arithmetic.and(Arithmetic.andAll(noneSignWords, tokens),
                Arithmetic.orAll(wordsWithPlusSign, tokens));

        if (beforeMinus.size() == 0)
            for (int i = 0; i < numberOfDocs; i++)
                beforeMinus.add(i);

        return Arithmetic.subtract(beforeMinus, Arithmetic.orAll(wordsWithMinusSign, tokens));

    }

}