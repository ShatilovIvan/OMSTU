using System;

struct Blank
{
    public string GetDate { get; set; }
    public string ReturnDate { get; set; }

    public Blank(string getDate, string returnDate)
    {
        GetDate = getDate;
        ReturnDate = returnDate;
    }
}
struct Book
{
    public string Author { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }
    public List<Blank> Blanks { get; set; }

    public Book(string author, string name, int year, string publisher, List<Blank> blanks)
    {
        Author = author;
        Name = name;
        Year = year;
        Publisher = publisher;
        Blanks = blanks;
    }
}

struct Library
{
    public List<Book> Books { get; set; }

    public Library(List<Book> books)
    {
        Books = books;
    }

    public List<Book> GetNeverBorrowedBooks()
    {
        List<Book> books = new List<Book>();

        foreach (Book book in Books)
        {
            if (book.Blanks.Count == 0 || book.Blanks == null)
            {
                books.Add(book);
            }
        }

        return books;
    }

    public List<Book> GetCurrentlyBorrowedBooks()
    {
        List<Book> books = new List<Book>();

        foreach (Book book in Books)
        {
            if (book.Blanks != null && book.Blanks.Count > 0)
            {
                Blank lastBlank = book.Blanks[book.Blanks.Count - 1];
                if (lastBlank.ReturnDate == null)
                {
                    books.Add(book);
                }
            }
        }

        return books;
    }
}

class Program
{
    static void Main()
    {
        var blank1 = new Blank("2023-01-01", "2023-01-15");
        var blank2 = new Blank("2023-02-01", null);
        var blank3 = new Blank("2023-03-01", "2023-03-15");

        var book1 = new Book("Author1", "Book1", 2000, "Pub1", new List<Blank>());
        var book2 = new Book("Author2", "Book2", 2001, "Pub2", new List<Blank> { blank1 });
        var book3 = new Book("Author3", "Book3", 2002, "Pub3", new List<Blank> { blank2 });
        var book4 = new Book("Author4", "Book4", 2003, "Pub4", new List<Blank> { blank1, blank3 });

        var library = new Library(new List<Book> { book1, book2, book3, book4 });

        var neverBorrowed = library.GetNeverBorrowedBooks();
        Console.WriteLine("Книги, которые никогда не были куплены:");
        foreach (var book in neverBorrowed)
        {
            Console.WriteLine($"{book.Author} - {book.Name}");
        }

        var currentlyBorrowed = library.GetCurrentlyBorrowedBooks();
        Console.WriteLine("\nКниги, которые не были возвращены:");
        foreach (var book in currentlyBorrowed)
        {
            Console.WriteLine($"{book.Author} - {book.Name}");
        }
    }
}
