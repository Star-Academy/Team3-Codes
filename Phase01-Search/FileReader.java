import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReader {
    String fileName;

    public FileReader() {
    }

    public String getFileContents(String fileName) {
        StringBuilder content = new StringBuilder();
        File file = new File(fileName);
        Scanner input = null;
        try {
            input = new Scanner(file);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        while (input.hasNext()) {
            content.append(input.nextLine());
        }
        input.close();
        return content.toString();
    }
}
