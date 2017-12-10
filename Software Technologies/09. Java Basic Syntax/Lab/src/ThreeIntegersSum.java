import java.util.Arrays;
import java.util.Scanner;

public class ThreeIntegersSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();

        if(numbers[0] == numbers[1] + numbers[2]) {
            System.out.printf("%d + %d = %d\n", Math.min(numbers[1], numbers[2]), Math.max(numbers[1], numbers[2]), numbers[0]);
        } else if (numbers[1] == numbers[0] + numbers[2]) {
            System.out.printf("%d + %d = %d\n", Math.min(numbers[0], numbers[2]), Math.max(numbers[0], numbers[2]), numbers[1]);
        } else if (numbers[2] == numbers[0] + numbers[1]) {
            System.out.printf("%d + %d = %d\n", Math.min(numbers[0], numbers[1]), Math.max(numbers[0], numbers[1]), numbers[2]);
        } else {
            System.out.printf("No");
        }
    }
}
