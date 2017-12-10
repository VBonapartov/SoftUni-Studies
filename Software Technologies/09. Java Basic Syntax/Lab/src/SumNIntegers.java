import java.util.Scanner;

public class SumNIntegers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num1 = scanner.nextInt();
        int totalSum = 0;
        for(int i = 0; i < num1; i++) {
            totalSum += scanner.nextInt();
        }

        System.out.printf("Sum = %d", totalSum);
    }
}
