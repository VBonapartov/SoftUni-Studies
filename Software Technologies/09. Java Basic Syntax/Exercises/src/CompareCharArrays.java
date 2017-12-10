import java.util.Scanner;

public class CompareCharArrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] arr1 = scanner.nextLine().trim().split("\\s");
        String[] arr2 = scanner.nextLine().trim().split("\\s");

        if (arr1[0].length() == 0 && arr2[0].length() == 0) {
            return;
        }
        else if (arr1[0].length() == 0) {
            PrintArray(arr2);
            return;
        }
        else if (arr2[0].length() == 0) {
            PrintArray(arr1);
            return;
        }

        boolean areEqual = false;
        boolean isFirstBigger = true;

        for (int i = 0; i < Math.min(arr1.length, arr2.length); i++) {
            if (arr1[i].equals(arr2[i])) {
                areEqual = true;
                continue;
            }

            isFirstBigger = (arr1[i].charAt(0) > arr2[i].charAt(0));
            break;
        }

        if (areEqual) {
            isFirstBigger = arr1.length > arr2.length;
        }

        if (isFirstBigger) {
            PrintArray(arr2);
            PrintArray(arr1);
        }
        else {
            PrintArray(arr1);
            PrintArray(arr2);
        }
    }

    public static void PrintArray(String[] arr) {
        for (int i = 0; i < arr.length; i++) {
            System.out.print(arr[i]);
        }

        System.out.println();
    }
}
