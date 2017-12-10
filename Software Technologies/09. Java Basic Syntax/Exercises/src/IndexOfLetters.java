import java.util.Arrays;
import java.util.Scanner;

public class IndexOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine().toLowerCase();

        for(int i = 0; i < input.length(); i++) {
            char symbol = input.charAt(i);
            System.out.printf("%s -> %d\n", symbol, (int)(symbol - 'a'));
        }
    }
}
