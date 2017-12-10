import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayList<Integer> numbers = AddInputTolist(scanner.nextLine().split("\\s"));

        int[] specNumbers = Arrays.stream(scanner.nextLine().split("\\s")).mapToInt(Integer::valueOf).toArray();
        int bombNumber = specNumbers[0];
        int power = specNumbers[1];

        while(numbers.indexOf(bombNumber) >= 0) {
            numbers = Explode(numbers, bombNumber, power);
        }

        System.out.println(Sum(numbers));
    }

    private static ArrayList<Integer> AddInputTolist(String[] strings) {
        ArrayList<Integer> numbers = new ArrayList<>();

        for (int i = 0; i < strings.length; i++) {
            numbers.add(Integer.parseInt(strings[i]));
        }

        return numbers;
    }

    private static ArrayList<Integer> Explode(ArrayList<Integer> numbers, int bombNumber, int power) {
        ArrayList<Integer> newNumbers = new ArrayList<>();

        int indexOfBomb = numbers.indexOf(bombNumber);

        int start = indexOfBomb - power;
        int end = indexOfBomb + power;

        start = (start < 0) ? 0 : start;
        end = (end > numbers.size() - 1) ? numbers.size() - 1 : end;

        for(int i = 0; i < numbers.size(); i++) {
            if(i < start || i > end) {
                newNumbers.add(numbers.get(i));
            }
        }

        return newNumbers;
    }

    private static int Sum(ArrayList<Integer> numbers) {
        int sum = 0;

        for (int i = 0; i < numbers.size(); i++) {
            sum += numbers.get(i);
        }

        return sum;
    }
}
