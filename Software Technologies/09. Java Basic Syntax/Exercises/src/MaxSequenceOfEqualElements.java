import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();

        int start = numbers[0];
        int len = 1;
        int bestStart = start;
        int bestLen = len;

        for(int i = 1; i < numbers.length; i++) {
            if(start == numbers[i]) {
                len++;
            } else {
                start = numbers[i];
                len = 1;
            }

            if (len > bestLen) {
                bestStart = start;
                bestLen = len;
            }
        }

        for(int i = 0; i < bestLen; i++) {
            System.out.print(bestStart + " ");
        }
    }
}
