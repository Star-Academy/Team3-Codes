import java.io.FilterInputStream;
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
    static ArrayList<String> wordsWithPlusSign = new ArrayList<>();
    static ArrayList<String> wordsWithMinusSign = new ArrayList<>();
    static ArrayList<String> noneSignWords = new ArrayList<>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        fillTheMap();
        assortTheWords(input);
        ArrayList<Integer> afterAndNonSign = andAll(noneSignWords);
        ArrayList<Integer> afterOrPlusSign = orAll(wordsWithPlusSign);
        ArrayList<Integer> beforeMinus = Arithmetic.and(afterAndNonSign, afterOrPlusSign);
        ArrayList<Integer> orOfminus = orAll(wordsWithMinusSign);
        ArrayList<Integer> result = Arithmetic.subtract(beforeMinus, orOfminus);
        for (Integer integer : result) {
            System.out.print(integer + " ");
        }
    }

    public static void fillTheMap() {
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        FileReader fileReader = new FileReader();

        try {
            DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get("Docs"));
            int i = 0;
            for (Path p : directoryStream) {
                invertedIndex.makeChanges(fileReader.getFileContents("Docs\\" + p.getFileName().toString()), i);
                i++;
            }
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    public static void assortTheWords(String input) {
        String[] splitInput = input.split(" ");
        Pattern pattern = Pattern.compile("(\\+|-)(\\w*)");

        for (String s : splitInput) {
            Matcher matcher = pattern.matcher(s);
            if (matcher.matches()) {
                switch (matcher.group(1)) {
                    case "+":
                        wordsWithPlusSign.add(matcher.group(2));
                        break;

                    case "-":
                        wordsWithMinusSign.add(matcher.group(2));
                        break;
                }
            } else
                noneSignWords.add(s);
        }

    }

    public static ArrayList<Integer> andAll(ArrayList<String> array) {
        ArrayList<Integer> andOfNoneSignWords = new ArrayList<>();
        String first = null;
        if (array.size() != 0) {
            first = array.get(0);
        }
        if (array.size() == 1) {
            return tokens.get(first);
        }
        if (array.size() >= 2) {
            andOfNoneSignWords = Arithmetic.and(tokens.get(first), tokens.get(array.get(1)));
        }
        for (int i = 2; i < array.size(); i++) {
            andOfNoneSignWords = Arithmetic.and(andOfNoneSignWords, tokens.get(array.get(i)));
        }
        return andOfNoneSignWords;
    }

    public static ArrayList<Integer> orAll(ArrayList<String> array) {
        ArrayList<Integer> andOfNoneSignWords = new ArrayList<>();
        String first = null;
        if (array.size() != 0) {
            first = array.get(0);
        }
        if (array.size() == 1) {
            return tokens.get(first);
        }
        if (array.size() >= 2) {
            andOfNoneSignWords = Arithmetic.or(tokens.get(first), tokens.get(array.get(1)));
        }
        for (int i = 2; i < array.size(); i++) {
            andOfNoneSignWords = Arithmetic.or(andOfNoneSignWords, tokens.get(array.get(i)));
        }
        return andOfNoneSignWords;
    }
}