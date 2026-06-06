namespace BookPublishingSystem;

/// <summary>
/// Represents a book in the publishing system.
/// </summary>
/// <param name="Title">The title of the book.</param>
/// <param name="Author">The author of the book.</param>
/// <param name="Year">The year the book was published.</param>
/// <param name="Content">The content of the book.</param>
public record Book(string Title, string Author, int Year, string Content);
