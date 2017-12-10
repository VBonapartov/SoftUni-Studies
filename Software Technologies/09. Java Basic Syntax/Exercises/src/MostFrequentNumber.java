import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();

        int mostFrequent = numbers[0];
        int maxCount = 1;

        for (int i = 0; i < numbers.length - 1; i++) {
            int counter = 1;
            for (int j = i + 1; j < numbers.length; j++) {
                if (numbers[i] == numbers[j]) {
                    counter++;
                }
            }

            if (counter > maxCount) {
                maxCount = counter;
                mostFrequent = numbers[i];
            }
        }

        System.out.println(mostFrequent);
    }
}
