using System;
using System.Collections.Generic;
using System.IO;

public class LibraryManager
{
    private string filePath = @"C:\Users\vivek\Documents\C Sharp practice\books.txt";

    public void AddBook()
    {
        Console.WriteLine("\n--- Add New Book ---");

        string id = Validation.GetBookID("Enter Book ID: ");

        // Check duplicate ID
        if (IsBookIDExists(id))
        {
            Console.WriteLine("Book ID already exists! Try another ID.");
            return;
        }

        Book b = new Book
        {
            BookID = id,
            BookName = Validation.GetNonEmptyString("Enter Book Name: "),
            Author = Validation.GetNonEmptyString("Enter Author Name: "),
            Year = Validation.GetYear("Enter Year (YYYY): "),
            Category = Validation.GetCategory("Enter Category: ")
        };

        File.AppendAllText(filePath, b.ToString() + Environment.NewLine);

        Console.WriteLine("Book Added Successfully!");
    }

    private bool IsBookIDExists(string id)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            Book b = Book.FromString(line);
            if (b.BookID == id)
                return true;
        }
        return false;
    }


    public void ViewBooks()
    {
        string[] lines = File.ReadAllLines(filePath);

        Console.WriteLine("\n--- All Books ---");
        foreach (string line in lines)
        {
            Book b = Book.FromString(line);
            Console.WriteLine($"{b.BookID} | {b.BookName} | {b.Author} | {b.Year} | {b.Category}");
        }
    }

    public void SearchBook()
    {
        string id = Validation.GetBookID("Enter Book ID to search: ");
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            Book b = Book.FromString(line);
            if (b.BookID == id)
            {
                Console.WriteLine("\nBook Found:");
                Console.WriteLine($"{b.BookID} | {b.BookName} | {b.Author} | {b.Year} | {b.Category}");
                return;
            }
        }

        Console.WriteLine("Book Not Found.");
    }


    public void DeleteBook()
    {
        string id = Validation.GetBookID("Enter Book ID to delete: ");

        string[] lines = File.ReadAllLines(filePath);
        List<string> updatedLines = new List<string>();
        bool found = false;

        foreach (string line in lines)
        {
            Book b = Book.FromString(line);
            if (b.BookID != id)
                updatedLines.Add(line);
            else
                found = true;
        }

        File.WriteAllLines(filePath, updatedLines);

        Console.WriteLine(found ? "Book Deleted!" : "Book ID Not Found.");
    }

}
