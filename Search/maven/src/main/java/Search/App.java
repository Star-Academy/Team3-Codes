package Search;

import java.io.IOException;
import java.util.Scanner;

public class App {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        
        try {

            FileReader reader = new FileReader("maven\\src\\main\\resources\\Docs");
            Processor processor = new Processor(reader);
            int numberOfDocs = processor.fillTheMap();

            System.out.println("Enter the string of words which you want to search .");
            for (Integer integer : processor.process(scanner.nextLine(), numberOfDocs))
                System.out.print(integer + " ");

            scanner.close();

        } catch (IOException e) {
            e.printStackTrace();
        }

    }

}