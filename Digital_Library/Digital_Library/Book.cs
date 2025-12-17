public class Book
{
    public string BookID { get; set; }
    public string BookName { get; set; }
    public string Author { get; set; }
    public string Year { get; set; }
    public string Category { get; set; }

    public override string ToString()
    {
        return $"{BookID}|{BookName}|{Author}|{Year}|{Category}";
    }

    public static Book FromString(string line)
    {
        string[] parts = line.Split('|');
        return new Book
        {
            BookID = parts[0],
            BookName = parts[1],
            Author = parts[2],
            Year = parts[3],
            Category = parts[4]
        };
    }
}
