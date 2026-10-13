using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Application.Dtos.BookCategory;

public record CreateBookCategoryRequest(
    [Required(ErrorMessage = "Kitap Kategori Adı boş geçilemez.." ),
    StringLength(200, ErrorMessage = "Kitap Kategori Adı en fazla 200 karakter olabilir..")]
    string Name
);