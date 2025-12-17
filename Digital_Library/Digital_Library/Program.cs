class Program
{
    public static void Main(string[] args)
    {
        LibraryManager lm = new LibraryManager();

        while (true)
        {
            Console.WriteLine("\n=== DIGITAL LIBRARY SYSTEM ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    lm.AddBook();
                    break;

                case 2:
                    lm.ViewBooks();
                    break;

                case 3:
                    lm.SearchBook();
                    break;

                case 4:
                    lm.DeleteBook();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
