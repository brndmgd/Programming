using System;

class IncorrectFormatException : Exception
{
    public IncorrectFormatException() { }
}

struct Book
{
    public string Owner;
    public string Title;
    public string Year;
    public string Publisher;
    public string ReturnDate;

    public Book(string owner, string title, string year, string publisher, string returnDate = "00.00.0000")
    {
        Owner = owner;
        Title = title;
        Year = year;
        Publisher = publisher;
        ReturnDate = returnDate;
    }

    public Book(string[] array)
    {
        Owner = array[0];
        Title = array[1];
        Year = array[2];
        Publisher = array[3];
        ReturnDate = array.Length == 5 ? array[4] : "00.00.0000";
    }
}

class Library
{
    public List<Book> Books;

    public Library()
    {
        Books = new List<Book>();
    }

    public Book[] NotInUse()
    {
        return Books.Where(x => x.ReturnDate == "00.00.0000").ToArray();
    }

    public Book[] InUse()
    {
        return Books.Where(x => x.ReturnDate != "00.00.0000").ToArray();
    }
}

class Program
{
    static void Print(Book book)
    {
        Console.WriteLine($"{book.Owner}, {book.Title}, {book.Year}, {book.Publisher}" + (book.ReturnDate != "00.00.0000" ? $", {book.ReturnDate}" : ""));
    }
    static void Main()
    {
        Library newLibrary = new Library();
        string? input = "";
        do
        {
            input = Console.ReadLine();
            if (input != "0" && input != null)
            {
                string[] arInput = input.Trim('/').Split("/");
                if (arInput.Length < 4 || arInput.Length > 5) throw new IncorrectFormatException();
                Book curBook = new Book(arInput);
                newLibrary.Books.Add(curBook);
            }
        } while (input != "0");
        Console.WriteLine("В использовании:");
        foreach (var i in newLibrary.InUse()) Print(i);
        Console.WriteLine();
        Console.WriteLine("В библиотеке:");
        foreach (var i in newLibrary.NotInUse()) Print(i);
    }
}