namespace LibrarySystem;

public class Book
{
    public int BookId { get; }
    public string Title { get; }
    public string Author { get; }
    public BookCategory Category { get; }
    public decimal DailyFee { get; }
    public bool IsAvailable { get; set; }

    public Book(int bookId, string title, string author, BookCategory category, decimal dailyFee, bool isAvailable = true)
    {
        if (bookId <= 0)
            throw new ArgumentException("BookId must be a positive number.", nameof(bookId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author cannot be empty.", nameof(author));

        if (dailyFee < 0)
            throw new ArgumentException("DailyFee cannot be negative.", nameof(dailyFee));

        BookId = bookId;
        Title = title;
        Author = author;
        Category = category;
        DailyFee = dailyFee;
        IsAvailable = isAvailable;
    }

    public override string ToString()
    {
        string availability = IsAvailable ? "Available" : "Borrowed";
        return $"[{BookId}] {Title} by {Author} ({Category}) - Daily Fee: R{DailyFee:F2} - {availability}";
    }

    public static decimal operator +(Book first, Book second)
    {
        if (first is null || second is null)
            throw new ArgumentNullException("Both books must be provided to add their fees.");

        return first.DailyFee + second.DailyFee;
    }

    public static bool operator ==(Book? first, Book? second)
    {
        if (ReferenceEquals(first, second))
            return true;

        if (first is null || second is null)
            return false;

        return first.BookId == second.BookId;
    }

    public static bool operator !=(Book? first, Book? second)
    {
        return !(first == second);
    }

    public static bool operator >(Book first, Book second)
    {
        if (first is null || second is null)
            throw new ArgumentNullException("Both books must be provided to compare fees.");

        return first.DailyFee > second.DailyFee;
    }

    public static bool operator <(Book first, Book second)
    {
        if (first is null || second is null)
            throw new ArgumentNullException("Both books must be provided to compare fees.");

        return first.DailyFee < second.DailyFee;
    }

    public override bool Equals(object? obj)
    {
        return obj is Book other && this == other;
    }

    public override int GetHashCode()
    {
        return BookId.GetHashCode();
    }
}
