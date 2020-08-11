package Search;

import java.util.ArrayList;
import java.util.regex.Pattern;
import java.util.regex.Matcher;

public class RegexOperator {

    static final String PLUS_REGEX = "(\\+)(\\w*)";
    static final String MINUS_REGEX = "(-)(\\w*)";
    static final String NONE_SIGN_REGEX = "^(\\w*)";

    public static ArrayList<String> assortTheWords(String input, String regex, int groupOfWordInRegex) {

        ArrayList<String> wordsThatMatch = new ArrayList<>();
        Pattern pattern = Pattern.compile(regex);
        String[] splitInput = input.split(" ");

        for (String s : splitInput) {
            Matcher matcher = pattern.matcher(s);
            if (matcher.matches())
                wordsThatMatch.add(matcher.group(groupOfWordInRegex));
        }
        return wordsThatMatch;
    }

}
