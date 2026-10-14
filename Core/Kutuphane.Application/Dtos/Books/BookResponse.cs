namespace Kutuphane.Application.Dtos.Books;

public record BookResponse(
    int Id,
    string Title,
    int AuthorId,
    int CategoryId,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);