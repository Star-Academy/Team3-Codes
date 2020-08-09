package Search;
import java.util.Scanner;

public class App {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Processor processor = new Processor();

        System.out.println("Enter path of directory which documents are located .");
        int numberOfDocs = processor.fillTheMap(scanner.nextLine());
        
        System.out.println("Enter the string of words which you want to search .");
        for (Integer integer : processor.process(scanner.nextLine(), numberOfDocs))
            System.out.print(integer + " ");

        scanner.close();
    }

<<<<<<< HEAD
    
=======
    public static int fillTheMap(HashMap<String, ArrayList<Integer>> tokens) {
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

>>>>>>> e2b904c21ba452c1b03400504054204a17b1414a
}