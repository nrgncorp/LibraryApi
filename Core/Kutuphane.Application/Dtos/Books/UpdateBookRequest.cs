using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Application.Dtos.Books;

public record UpdateBookRequest(
    [Required(ErrorMessage = "Kitap Adı boş geçilemez.." ),
    StringLength(200, ErrorMessage = "Kitap Adı en fazla 200 karakter olmalıdır..")]
    string Title,

    [Required(ErrorMessage = "Yazar boş geçilemez.." ), Range(1, int.MaxValue, ErrorMessage = "Geçerli bir yazar seçiniz..")]
    int? AuthorId
);