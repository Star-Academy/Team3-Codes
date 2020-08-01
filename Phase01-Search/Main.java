import javafx.scene.control.skin.CellSkinBase;

import javax.swing.*;
import java.io.IOException;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class  Main {
    static HashMap<String, ArrayList<Integer>> tokens = new HashMap<>();
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String word = scanner.nextLine();
        fillingTheMap();
        if(tokens.containsKey(word.toLowerCase()))
             for (Integer integer : tokens.get(word.toLowerCase())) {
                 System.out.println(integer);
              }
        else
            System.err.println("The word does not exist !");


    }





    public static void fillingTheMap(){
        InvertedIndex invertedIndex = new InvertedIndex(tokens);
        FileReader fileReader = new FileReader();

        try {
            DirectoryStream<Path> directoryStream = Files.newDirectoryStream(Paths.get("Phase01-Search\\Docs"));
            int i = 0 ;
            for (Path p : directoryStream) {
                invertedIndex.makeChanges(fileReader.getFileContents("Phase01-Search\\Docs\\"+p.getFileName().toString()),i);
                i++ ;
            }
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}