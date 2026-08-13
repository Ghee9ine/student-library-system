using LibrarySystem;

Library library = new Library();

RunMenu();

void RunMenu()
{
    bool isRunning = true;

    while (isRunning)
    {
        DisplayMenu();
        string? choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    RegisterStudent();
                    break;
                case "2":
                    AddBook();
                    break;
                case "3":
                    DisplayBooks();
                    break;
                case "4":
                    SearchBook();
                    break;
                case "5":
                    RemoveBook();
                    break;
                case "6":
                    CalculateTotalBorrowingFee();
                    break;
                case "7":
                    CompareTwoBooks();
                    break;
                case "0":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a number from the menu.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        if (isRunning)
        {
            Console.WriteLine();
        }
    }
}

void DisplayMenu()
{
    Console.WriteLine("===== UNIVERSITY LIBRARY SYSTEM =====");
    Console.WriteLine("1. Register Student");
    Console.WriteLine("2. Add Book");
    Console.WriteLine("3. Display Books");
    Console.WriteLine("4. Search Book");
    Console.WriteLine("5. Remove Book");
    Console.WriteLine("6. Calculate Total Borrowing Fee");
    Console.WriteLine("7. Compare Two Books");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
}

void RegisterStudent()
{
    Console.Write("Enter Student Number: ");
    string studentNumber = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter Full Name: ");
    string fullName = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter Course: ");
    string course = Console.ReadLine() ?? string.Empty;

    if (string.IsNullOrWhiteSpace(studentNumber) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(course))
        throw new ArgumentException("Student number, full name and course are all required.");

    library.RegisterStudent(new StudentRecord(studentNumber, fullName, course));

    Console.WriteLine("Student registered successfully.");
}

void AddBook()
{
    Console.Write("Enter Book Id: ");
    int bookId = int.Parse(Console.ReadLine() ?? string.Empty);

    Console.Write("Enter Title: ");
    string title = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter Author: ");
    string author = Console.ReadLine() ?? string.Empty;

    BookCategory category = PromptForCategory();

    Console.Write("Enter Daily Fee: ");
    decimal dailyFee = decimal.Parse(Console.ReadLine() ?? string.Empty);

    library.AddBook(new Book(bookId, title, author, category, dailyFee));

    Console.WriteLine("Book added successfully.");
}

BookCategory PromptForCategory()
{
    Console.WriteLine("Select Category: 1) Technology 2) Science 3) Literature 4) History 5) Other");
    Console.Write("Enter choice: ");
    string? categoryChoice = Console.ReadLine();

    return categoryChoice switch
    {
        "1" => BookCategory.Technology,
        "2" => BookCategory.Science,
        "3" => BookCategory.Literature,
        "4" => BookCategory.History,
        "5" => BookCategory.Other,
        _ => throw new ArgumentException("Invalid category selection.")
    };
}

void DisplayBooks()
{
    if (library.Student is not null)
    {
        Console.WriteLine($"Student Number : {library.Student.StudentNumber}");
        Console.WriteLine($"Student Name   : {library.Student.FullName}");
        Console.WriteLine($"Course         : {library.Student.Course}");
        Console.WriteLine();
    }

    Console.WriteLine("Borrowed Books");
    library.DisplayBooks();
}

void SearchBook()
{
    Console.Write("Enter title to search for: ");
    string title = Console.ReadLine() ?? string.Empty;

    Book? foundBook = library.SearchBook(title);

    Console.WriteLine(foundBook is not null ? foundBook.ToString() : "No book found matching that title.");
}

void RemoveBook()
{
    Console.Write("Enter Book Id to remove: ");
    int bookId = int.Parse(Console.ReadLine() ?? string.Empty);

    bool wasRemoved = library.RemoveBook(bookId);

    Console.WriteLine(wasRemoved ? "Book removed successfully." : "No book found with that Id.");
}

void CalculateTotalBorrowingFee()
{
    decimal totalFee = library.CalculateTotalBorrowingFee();
    Console.WriteLine($"Total Borrowing Fee : R{totalFee:F2}");
}

void CompareTwoBooks()
{
    Console.Write("Enter first Book Id: ");
    int firstId = int.Parse(Console.ReadLine() ?? string.Empty);

    Console.Write("Enter second Book Id: ");
    int secondId = int.Parse(Console.ReadLine() ?? string.Empty);

    Book firstBook = library.Books.FirstOrDefault(book => book.BookId == firstId)
        ?? throw new InvalidOperationException($"No book found with Id {firstId}.");
    Book secondBook = library.Books.FirstOrDefault(book => book.BookId == secondId)
        ?? throw new InvalidOperationException($"No book found with Id {secondId}.");

    Console.WriteLine($"Combined Daily Fee : R{firstBook + secondBook:F2}");
    Console.WriteLine($"Book 1 == Book 2 : {firstBook == secondBook}");
    Console.WriteLine($"Book 1 != Book 2 : {firstBook != secondBook}");
    Console.WriteLine($"Book 1 > Book 2  : {firstBook > secondBook}");
    Console.WriteLine($"Book 1 < Book 2  : {firstBook < secondBook}");
}
