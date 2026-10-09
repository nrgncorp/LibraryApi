namespace Kutuphane.Application.Dtos.Books;

public record BookResponse(
    int Id,
    string Title,
    int AuthorId,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);