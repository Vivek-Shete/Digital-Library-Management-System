using System;
using System.Text.RegularExpressions;

public static class Validation
{
    public static string GetNonEmptyString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Value cannot be empty. Try again.");
        }
    }

    public static string GetBookID(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[0-9]+$"))
                return input;

            Console.WriteLine("Invalid Book ID! Only numeric values allowed.");
        }
    }

    public static string GetYear(string message)
    {
        while (true)
        {
            Console.Write(message);
            string year = Console.ReadLine();

            if (Regex.IsMatch(year, @"^(19|20)\d{2}$"))
                return year;

            Console.WriteLine("Invalid Year! Enter a valid year like 1999 or 2023.");
        }
    }

    public static string GetCategory(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (Regex.IsMatch(input, @"^[A-Za-z ]+$"))
                return input;

            Console.WriteLine("Category must contain only alphabets.");
        }
    }
}
