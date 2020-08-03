
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

        ArrayList<Integer> beforeMinus = Arithmetic.and(Arithmetic.andAll(noneSignWords, tokens),
                Arithmetic.orAll(wordsWithPlusSign, tokens));

        if (beforeMinus.size() == 0) {
            for (int i = 0; i < numberOfDocs; i++)
                beforeMinus.add(i);
        }

        ArrayList<Integer> result = Arithmetic.subtract(beforeMinus, Arithmetic.orAll(wordsWithMinusSign, tokens));

        for (Integer integer : result) {
            System.out.print(integer + " ");
        }
        scanner.close();
    }

    public static int fillTheMap() {
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        int i = 0;
        try {
            DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get("Docs"));
            for (Path p : directoryStream) {
                invertedIndex.makeChanges(FileReader.getFileContents("Docs\\" + p.getFileName().toString()), i);
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
            if (matcher.matches())
                wordsThatMatch.add(matcher.group(groupOfWordInRegex));
        }
        return wordsThatMatch;
    }
}