namespace LibrarySystem;

public class Library
{
    public StudentRecord? Student { get; private set; }
    public List<Book> Books { get; } = new List<Book>();

    public void RegisterStudent(StudentRecord student)
    {
        Student = student ?? throw new ArgumentNullException(nameof(student));
    }

    public void AddBook(Book book)
    {
        if (book is null)
            throw new ArgumentNullException(nameof(book));

        if (Books.Any(existing => existing.BookId == book.BookId))
            throw new InvalidOperationException($"A book with BookId {book.BookId} already exists.");

        Books.Add(book);
    }

    public bool RemoveBook(int bookId)
    {
        Book? bookToRemove = Books.FirstOrDefault(book => book.BookId == bookId);

        if (bookToRemove is null)
            return false;

        Books.Remove(bookToRemove);
        return true;
    }

    public Book? SearchBook(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Search title cannot be empty.", nameof(title));

        return Books.FirstOrDefault(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("No books have been added yet.");
            return;
        }

        foreach (Book book in Books)
        {
            Console.WriteLine(book);
        }
    }

    public decimal CalculateTotalBorrowingFee()
    {
        decimal total = 0m;

        foreach (Book book in Books)
        {
            total += book.DailyFee;
        }

        return total;
    }
}
