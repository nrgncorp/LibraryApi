namespace Kutuphane.Application.Dtos.BookCategory;

public record BookCategoryResponse(
    int Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);