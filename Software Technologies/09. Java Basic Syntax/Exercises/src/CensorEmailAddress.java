import java.util.Collections;
import java.util.Scanner;

public class CensorEmailAddress {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String email = scanner.nextLine();
        String text = scanner.nextLine();

        String[] emailDetails = email.split("@");
        String username = emailDetails[0];
        String domain = emailDetails[1];

        String replacement = String.join("", Collections.nCopies(username.length(), "*")) + "@" + domain;

        text = text.replaceAll(email, replacement);
        System.out.println(text);
    }
}
