import java.util.Scanner;

public class ReverseCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        StringBuilder sb = new StringBuilder(3);
        for(int i = 0; i < 3; i++) {
            sb.append(scanner.nextLine());
        }

        String reverseString = sb.reverse().toString();
        System.out.println(reverseString);
    }
}
