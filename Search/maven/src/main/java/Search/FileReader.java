package Search;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReader {

    public static String getFileContents(String fileName) {
        StringBuilder content = new StringBuilder();
        Scanner input = null;
        try {
            input = new Scanner(new File(fileName));
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        while (input.hasNext())
            content.append(input.nextLine());
        input.close();
        return content.toString();
    }
}
