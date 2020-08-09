package Search;
import java.util.Scanner;

public class App {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Processor processor = new Processor();

        // System.out.println("Enter path of directory which documents are located .");
        // int numberOfDocs = processor.fillTheMap(scanner.nextLine());
         int numberOfDocs = processor.fillTheMap("maven\\src\\main\\resources\\Docs");
        
        System.out.println("Enter the string of words which you want to search .");
        for (Integer integer : processor.process(scanner.nextLine(), numberOfDocs))
            System.out.print(integer + " ");

        scanner.close();
    }

}