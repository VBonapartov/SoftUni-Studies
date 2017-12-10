import java.util.ArrayList;
import java.util.Scanner;

public class SymmetricNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num = scanner.nextInt();

        ArrayList<Integer> symmetricNumbers = new ArrayList<Integer>();
        for(int i = 1; i <= num; i++)
        {
            if(IsSymmetric(i)) {
                symmetricNumbers.add(i);
            }
        }

        for (int i = 0; i < symmetricNumbers.size(); i++) {
            System.out.printf("%d ", symmetricNumbers.get(i));
        }
    }

    private static boolean IsSymmetric(int number) {
        String numToStr = String.valueOf(number);
        int numLen = numToStr.length();

        for(int i = 0; i < numLen / 2; i++) {
            if (numToStr.charAt(i) != numToStr.charAt(numLen - 1 - i)) {
                return false;
            }
        }

        return true;
    }
}
