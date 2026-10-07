using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Application.Dtos.Books;

public record CreateBookRequest(
    [Required(ErrorMessage = "Kitap Adı boş geçilemez.." ),
    StringLength(200, ErrorMessage = "Kitap Adı en fazla 200 karakter olabilir..")]
    string Title,

    [Required(ErrorMessage = "Yazar Adı boş geçilemez.." ),
    StringLength(100, ErrorMessage = "Yazar adı en fazla 100 karakter olabilir.."),
    RegularExpression(@"^[^0-9]*$", ErrorMessage = "Yazar Adı rakam içeremez..")]
    string Author
);