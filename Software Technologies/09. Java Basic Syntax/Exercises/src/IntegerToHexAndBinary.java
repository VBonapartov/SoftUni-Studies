import java.util.Scanner;

public class IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());
        System.out.println(decimal2hex(number));
        System.out.println(decimal2binary(number));

        //System.out.println(Integer.toHexString(number).toUpperCase());
        //System.out.println(Integer.toBinaryString(number));
    }

    public static String decimal2hex(int d) {
        String digits = "0123456789ABCDEF";
        if (d <= 0) return "0";
        int base = 16;                          // flexible to change in any base under 16
        String hex = "";
        while (d > 0) {
            int digit = d % base;               // rightmost digit
            hex = digits.charAt(digit) + hex;   // string concatenation
            d = d / base;
        }
        return hex;
    }

    public static String decimal2binary(int d) {
        String digits = "01";
        if (d <= 0) return "0";
        int base = 2;                          // flexible to change in any base under 16
        String hex = "";
        while (d > 0) {
            int digit = d % base;               // rightmost digit
            hex = digits.charAt(digit) + hex;   // string concatenation
            d = d / base;
        }
        return hex;
    }
}
