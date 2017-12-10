import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, String> phonebook = new TreeMap<String, String>();

        String input = "";
        while(!"END".equals(input = scanner.nextLine())) {
            String[] commandArgs = input.split("\\s");
            String command = commandArgs[0];

            switch (command) {
                case "A":
                    AddToPhonebook(phonebook, commandArgs[1], commandArgs[2]);
                    break;

                case "S":
                    SearchContactByName(phonebook, commandArgs[1]);
                    break;

                case "ListAll":
                    ListAll(phonebook);
                    break;
            }
        }
    }

    private static void AddToPhonebook(Map<String, String> phonebook, String name, String phone) {
        phonebook.put(name, phone);
    }

    private static void SearchContactByName(Map<String, String> phonebook, String name) {
        if (phonebook.containsKey(name)) {
            System.out.printf("%s -> %s\n", name, phonebook.get(name));
        } else {
            System.out.printf("Contact %s does not exist.\n", name);
        }
    }

    private static void ListAll(Map<String, String> phonebook) {
        for (Map.Entry<String, String> entry : phonebook.entrySet()) {
            System.out.printf("%s -> %s\n", entry.getKey(), entry.getValue());
        }
    }
}
