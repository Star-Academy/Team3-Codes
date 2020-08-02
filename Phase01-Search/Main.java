import javafx.css.Match;

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

public class  Main {
    static HashMap<String, ArrayList<Integer>> tokens = new HashMap<>();
    static ArrayList<String> wordsWithPlusSign = new ArrayList<>();
    static ArrayList<String> wordsWithMinusSign = new ArrayList<>();
    static ArrayList<String> noneSignWords = new ArrayList<>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        fillTheMap();
        assortTheWords(input);
//        if(tokens.containsKey(word.toLowerCase()))
//             for (Integer integer : tokens.get(word.toLowerCase())) {
//                 System.out.print(integer + " ");
//              }
//        else
//            System.err.println("The word does not exist !");


    }

    public static void fillTheMap(){
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        FileReader fileReader = new FileReader();

        try {
            DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get("Docs"));
            int i = 0 ;
            for (Path p : directoryStream) {
                invertedIndex.makeChanges(fileReader.getFileContents("Docs\\"+p.getFileName().toString()),i);
                i++ ;
            }
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    public static void assortTheWords(String input){
        String[] splitInput = input.split(" ");
        Pattern pattern = Pattern.compile("(\\+|-)(\\w*)");

        for (String s : splitInput) {
            Matcher matcher = pattern.matcher(s);
            if(matcher.matches()) {
                switch (matcher.group(1)) {
                    case "+":
                        wordsWithPlusSign.add(matcher.group(2));
                        break;

                    case "-":
                        wordsWithMinusSign.add(matcher.group(2));
                        break;
                }
            }
            else
                noneSignWords.add(s);
        }

    }
}