import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char symbol = scanner.next().charAt(0);

        if(Character.isDigit(symbol)) {
            System.out.println("digit");
        } else if("aeiou".indexOf(symbol) >= 0 || "aeiou".toUpperCase().indexOf(symbol) >= 0) {
            System.out.println("vowel");
        } else {
            System.out.println("other");
        }
    }
}
