import java.util.Scanner;

public class ChangeToUppercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        while(text.contains("<upcase>")) {
            int startIdx = text.indexOf("<upcase>");
            int endIdx = text.indexOf("</upcase>");

            String uppercaseText = text.substring(startIdx + 8, endIdx).toUpperCase();
            text = text.substring(0, startIdx)  + uppercaseText + text.substring(endIdx + 9);
        }

        System.out.println(text);
    }
}
