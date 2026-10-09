using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Application.Dtos.Books;

public record CreateBookRequest(
    [Required(ErrorMessage = "Kitap Adı boş geçilemez.." ),
    StringLength(200, ErrorMessage = "Kitap Adı en fazla 200 karakter olabilir..")]
    string Title,

    [Required(ErrorMessage = "Yazar Adı boş geçilemez.." ), Range(1, int.MaxValue, ErrorMessage = "Geçerli bir yazar seçiniz..")]
    int? AuthorId
);