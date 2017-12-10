import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceOfIncreasingElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();

        int start = numbers[0];
        int len = 1;
        int bestLen = len;

        int startIndexOfSequence = 0;
        int bestStartIndexOfSequence = startIndexOfSequence;
        for(int i = 1; i < numbers.length; i++) {
            if(numbers[i] > start) {
                len++;
            } else {
                len = 1;
                startIndexOfSequence = i;
            }
            start = numbers[i];

            if (len > bestLen) {
                bestStartIndexOfSequence = startIndexOfSequence;
                bestLen = len;
            }
        }

        for(int i = 0; i < bestLen; i++) {
            System.out.print(numbers[bestStartIndexOfSequence++] + " ");
        }
    }
}
