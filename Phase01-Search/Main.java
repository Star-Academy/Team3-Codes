
import java.io.IOException;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    static HashMap<String, ArrayList<Integer>> tokens = new HashMap<>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        int numberOfDocs = fillTheMap();

        ArrayList<String> wordsWithPlusSign = assortTheWords(input, "(\\+)(\\w*)", 2);
        ArrayList<String> wordsWithMinusSign = assortTheWords(input, "(-)(\\w*)", 2);
        ArrayList<String> noneSignWords = assortTheWords(input, "^(\\w*)", 1);

        ArrayList<Integer> beforeMinus = Arithmetic.and(andAll(noneSignWords), orAll(wordsWithPlusSign));

        if (beforeMinus.size() == 0) {
            for (int i = 0; i < numberOfDocs; i++)
                beforeMinus.add(i);
        }

        ArrayList<Integer> result = Arithmetic.subtract(beforeMinus, orAll(wordsWithMinusSign));

        for (Integer integer : result) {
            System.out.print(integer + " ");
        }
        scanner.close();
    }

    public static int fillTheMap() {
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        FileReader fileReader = new FileReader();
        int i = 0;
        try {
            DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get("Docs"));
            for (Path p : directoryStream) {
                invertedIndex.makeChanges(fileReader.getFileContents("Docs\\" + p.getFileName().toString()), i);
                i++;
            }
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        return i;
    }

    public static ArrayList<String> assortTheWords(String input, String regex, int groupOfWordInRegex) {

        ArrayList<String> wordsThatMatch = new ArrayList<>();
        Pattern pattern = Pattern.compile(regex);
        String[] splitInput = input.split(" ");

        for (String s : splitInput) {
            Matcher matcher = pattern.matcher(s);
            if (matcher.matches()) {
                wordsThatMatch.add(matcher.group(groupOfWordInRegex));
            }
        }
        return wordsThatMatch;
    }

    public static ArrayList<Integer> andAll(ArrayList<String> array) {
        return array.stream().map(a -> tokens.get(a)).reduce((a, b) -> Arithmetic.and(a, b)).orElse(new ArrayList<>());
    }

    public static ArrayList<Integer> orAll(ArrayList<String> array) {
        return array.stream().map(a -> tokens.get(a)).reduce((a, b) -> Arithmetic.or(a, b)).orElse(new ArrayList<>());
    }
}