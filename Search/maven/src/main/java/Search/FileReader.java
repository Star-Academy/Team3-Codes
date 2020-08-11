package Search;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Iterator;
import java.util.Scanner;

public class FileReader implements Reader {
    private final DirectoryStream<Path> directoryStream;
    private final Iterator<Path> iterator;

    public FileReader(String directoryPath) throws IOException {
        this.directoryStream = Files.newDirectoryStream(Paths.get(directoryPath));
        this.iterator = this.directoryStream.iterator();
    }

    public boolean hasNext() {
        return this.iterator.hasNext();
    }

    public String next() {
        Path fileName = iterator.next();
        return getFileContents(fileName);
    }

    private String getFileContents(Path fileName) {
        StringBuilder content = new StringBuilder();
        Scanner input = null;

        try {
            input = new Scanner(fileName.toFile());
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        while (input.hasNext())
            content.append(input.nextLine());
        input.close();
        return content.toString();
    }
}
