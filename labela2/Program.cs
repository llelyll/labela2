using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }

    public override string ToString()
    {
        return $"{Title} by {Author}, published by {Publisher}";
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public List<Book> FindBooksByAuthor(string author)
    {
        return books.Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> GetBooksSortedByTitle()
    {
        return books.OrderBy(book => book.Title).ToList();
    }

    public override string ToString()
    {
        if (books.Count == 0)
            return "Library is empty.";

        return string.Join(Environment.NewLine, books);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook(new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Publisher = "Scribner" });
        library.AddBook(new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Publisher = "J.B. Lippincott & Co." });
        library.AddBook(new Book { Title = "1984", Author = "George Orwell", Publisher = "Secker & Warburg" });

        Console.WriteLine("All books in the library:");
        Console.WriteLine(library);

        string authorToSearch = "Harper Lee";
        List<Book> booksByAuthor = library.FindBooksByAuthor(authorToSearch);
        Console.WriteLine($"\nBooks by {authorToSearch}:");
        foreach (var book in booksByAuthor)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\nBooks sorted by title:");
        foreach (var book in library.GetBooksSortedByTitle())
        {
            Console.WriteLine(book);
        }

        Book bookToRemove = new Book { Title = "1984", Author = "George Orwell", Publisher = "Secker & Warburg" };
        library.RemoveBook(bookToRemove);
        Console.WriteLine("\nAfter removing book:");
        Console.WriteLine(library);
        Console.ReadLine();
    }
}