using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Application.Dtos.BookCategory;

public record UpdateBookCategoryRequest(
    [Required(ErrorMessage = "Kitap Kategori Adı boş geçilemez.." ),
    StringLength(200, ErrorMessage = "Kitap Kategori Adı en fazla 200 karakter olmalıdır..")]
    string Name,

    bool IsActive
);