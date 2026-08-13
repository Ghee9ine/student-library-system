# student-library-system

A C# console application demonstrating custom types and operator overloading.

## Scenario

A Student Library Management System that allows a librarian to register students, add books, manage borrowed books, calculate borrowing fees and compare books.

## Structure

- `BookCategory.cs` - enum with members Technology, Science, Literature, History, Other
- `StudentRecord.cs` - record with StudentNumber, FullName, Course
- `Book.cs` - class with validation, an overridden ToString(), and overloaded `+`, `==`, `!=`, `>`, `<` operators
- `Library.cs` - manages a StudentRecord and a List<Book>, with methods to add, remove, search and display books and calculate the total borrowing fee
- `Program.cs` - console menu tying everything together

## Running

```
dotnet run
```

### Menu

```
1. Register Student
2. Add Book
3. Display Books
4. Search Book
5. Remove Book
6. Calculate Total Borrowing Fee
7. Compare Two Books
0. Exit
```
