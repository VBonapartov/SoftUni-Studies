import java.util.*;

public class Phonebook {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LinkedHashMap<String, String> phonebook = new LinkedHashMap<>();

        String input = "";
        while(!"END".equals(input = scanner.nextLine())) {
            String[] commandArgs = input.split("\\s");
            String command = commandArgs[0];
            String name = commandArgs[1];

            switch (command) {
                case "A":
                    String phone = commandArgs[2];
                    AddToPhonebook(phonebook, name, phone);
                    break;

                case "S":
                    SearchContactByName(phonebook, name);
                    break;
            }
        }
    }

    private static void AddToPhonebook(LinkedHashMap<String, String> phonebook, String name, String phone) {
        phonebook.put(name, phone);
    }

    private static void SearchContactByName(LinkedHashMap<String, String> phonebook, String name) {
        if (phonebook.containsKey(name)) {
            System.out.printf("%s -> %s\n", name, phonebook.get(name));
        } else {
            System.out.printf("Contact %s does not exist.\n", name);
        }
    }
}
