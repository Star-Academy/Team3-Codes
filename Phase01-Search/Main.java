import java.io.IOException;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class Main {
    static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        Processor processor = new Processor();
        int numberOfDocs = fillTheMap(processor.getTokens());

        for (Integer integer : processor.process(scanner.nextLine(), numberOfDocs))
            System.out.print(integer + " ");

        scanner.close();
    }

    private static int fillTheMap(HashMap<String, ArrayList<Integer>> tokens) {
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        String fileName = "Docs";
        int i = 0;
        try {
            DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get(fileName));
            for (Path p : directoryStream) {
                invertedIndex.makeChanges(FileReader.getFileContents(fileName + "\\" + p.getFileName().toString()), i);
                i++;
            }
            directoryStream.close();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        return i;
    }

}