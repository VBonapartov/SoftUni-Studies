import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class BookLibraryModification {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numberOfBooks = Integer.parseInt(scanner.nextLine());

        Library library = new Library("Library", new ArrayList<Book>());
        for (int i = 0; i < numberOfBooks; i++) {
            library.getBooks().add(ReadBook(scanner));
        }

        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        Calendar dateAfter = Calendar.getInstance();
        try {
            dateAfter.setTime(dateFormat.parse(scanner.nextLine()));
            PrintTitlesAfterDate(library, dateAfter, dateFormat);
        } catch (ParseException e) {
            // error: "Invalid Date"
        }
    }

    private static Book ReadBook(Scanner scanner) {
        String[] input = scanner.nextLine().trim().split("\\s"); ;

        String title = input[0];
        String author = input[1];
        String publisher = input[2];

        Calendar releaseDate = Calendar.getInstance();
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        try {
            releaseDate.setTime(dateFormat.parse(input[3]));
        } catch (ParseException e) {
            // error: "Invalid Date!");
            // ...
        }

        String isbn = input[4];
        double price = Double.parseDouble(input[5]);

        return new Book(title, author, publisher, releaseDate, isbn, price);
    }

    private static void PrintTitlesAfterDate(Library library, Calendar dateAfter, SimpleDateFormat dateFormat) {
        HashMap<String, Calendar> titleDate = new HashMap<>();

        for (Book book : library.getBooks()) {
            if (book.getReleaseDate().compareTo(dateAfter) > 0) {
                titleDate.put(book.getTitle(), book.getReleaseDate());
            }
        }

        // Sorting by Date and then by Title lexicographically
        titleDate.entrySet().stream()
                .sorted(Map.Entry.<String, Calendar>comparingByKey())
                .sorted(Map.Entry.<String, Calendar>comparingByValue())
                .forEachOrdered(b -> System.out.printf("%s -> %s\n", b.getKey(), dateFormat.format(b.getValue().getTime())));
    }
}

class Book
{
    private String Title;
    private String Author;
    private String Publisher;
    private Calendar ReleaseDate;
    private String ISBN;
    private double Price;

    public Book(String title, String author, String publisher, Calendar releaseDate, String isbn, double price) {
        this.Title = title;
        this.Author = author;
        this.Publisher = publisher;
        this.ReleaseDate = releaseDate;
        this.ISBN = isbn;
        this.Price = price;
    }

    public String getTitle() {
        return this.Title;
    }

    public void setTitle(String title) {
        this.Title = title;
    }

    public String getAuthor() {
        return this.Author;
    }

    public void setAuthor(String author) {
        this.Author = author;
    }

    public String getPublisher() {
        return this.Publisher;
    }

    public void setPublisher(String publisher) {
        this.Publisher = publisher;
    }

    public Calendar getReleaseDate() {
        return this.ReleaseDate;
    }

    public void setReleaseDate(Calendar releaseDate) {
        this.ReleaseDate = releaseDate;
    }

    public String getISBN() {
        return this.ISBN;
    }

    public void setISBN(String ISBN) {
        this.ISBN = ISBN;
    }

    public double getPrice() {
        return this.Price;
    }

    public void setPrice(double price) {
        this.Price = price;
    }
}

class Library
{
    private String Name;
    private ArrayList<Book> Books = new ArrayList<Book>();

    public Library(String name, ArrayList<Book> books) {
        this.Name = name;
        this.Books = books;
    }

    public String getName() {
        return this.Name;
    }

    public void setName(String name) {
        this.Name = name;
    }

    public ArrayList<Book> getBooks() {
        return this.Books;
    }

    public void setBooks(ArrayList<Book> books) {
        this.Books = books;
    }
}
