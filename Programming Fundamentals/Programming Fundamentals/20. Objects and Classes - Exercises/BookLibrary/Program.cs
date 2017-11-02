using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate  { get; set; }
        public string ISBNNumber  { get; set; }
        public decimal Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBooks = int.Parse(Console.ReadLine());

            Library library = new Library();
            library.Books = new List<Book>();
            for (int i = 0; i < numberOfBooks; i++)
                library.Books.Add(ReadBook());

            PrintBooks(library.Books);
        }

        static private Book ReadBook()
        {
            string[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;

            Book book = new Book
            {
                Title = input[0],
                Author = input[1],
                Publisher = input[2],
                ReleaseDate = DateTime.ParseExact(input[3], "d.M.yyyy", CultureInfo.InvariantCulture),
                ISBNNumber = input[4],
                Price = decimal.Parse(input[5])
            };

            return book;
        }

        static private void PrintBooks(List<Book> listOfBooks)
        {
            List<string> booksForPrint = listOfBooks
                                            .GroupBy(b => b.Author)
                                            .OrderByDescending(a => a.Sum(p => p.Price))
                                            .ThenBy(a => a.Key)
                                            .Select(a => a.Key + " -> " + string.Format($"{a.Sum(p => p.Price):F2}"))
                                            .ToList();

            Console.WriteLine($"{String.Join(Environment.NewLine, booksForPrint)}");
        }
    }
}
