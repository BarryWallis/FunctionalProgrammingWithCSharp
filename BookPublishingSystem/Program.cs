// Pure function to validate a book
using BookPublishingSystem;

List<Book> books =
  [
       new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "In my younger and more vulnerable years..."),
       new Book("To Kill a Mockingbird", "Harper Lee", 1960, "When he was nearly thirteen, my brother Jem..."),
       new Book("Invalid Book", "", 1800, ""),
       new Book("1984", "George Orwell", 1949,"It was a bright cold day in April, and the clocks were striking thirteen.")
  ];

string FormatBook(Book book) => $"{book.Title} by {book.Author} ({book.Year})";

bool IsValid(Book book)
    => !string.IsNullOrEmpty(book.Title) 
       && !string.IsNullOrEmpty(book.Author) 
       && book.Year > 1900 
       && !string.IsNullOrEmpty(book.Content);

IEnumerable<T> ProcessBooks<T>(IEnumerable<Book> books, Func<Book, bool> validator, Func<Book, T> formatter)
    => books.Where(validator).Select(formatter);

Console.WriteLine("Processed books:");


// Using our higher-order function to process books
IEnumerable<string> formattedBooks = ProcessBooks(books, IsValid, FormatBook);
foreach (string book in formattedBooks)
{
    Console.WriteLine(book);
}

