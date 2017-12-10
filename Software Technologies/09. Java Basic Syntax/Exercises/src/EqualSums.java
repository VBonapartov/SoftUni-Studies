import java.util.Arrays;
import java.util.Scanner;

public class EqualSums {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();
        boolean isFind = false;
        for(int i = 0; i < numbers.length; i++) {
            if(LeftSum(numbers, i) == RightSum(numbers, i)) {
                System.out.println(i);
                isFind = true;
                break;
            }
        }

        if(!isFind) {
            System.out.println("no");
        }
    }

    public static int LeftSum(int[] numbers, int index) {
        if(index <= 0) {
            return 0;
        }

        int leftSum = 0;
        for(int i = index - 1; i >= 0; i--) {
            leftSum += numbers[i];
        }

        return leftSum;
    }

    public static int RightSum(int[] numbers, int index) {
        if(index >= numbers.length - 1) {
            return 0;
        }

        int rightSum = 0;
        for(int i = index + 1; i < numbers.length; i++) {
            rightSum += numbers[i];
        }

        return rightSum;
    }
}
