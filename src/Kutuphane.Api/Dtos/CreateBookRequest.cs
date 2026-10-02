using System.ComponentModel.DataAnnotations;
namespace KutuphaneApi.Dtos;

public record CreateBookRequest(
    [Required(ErrorMessage = "Kitap Adı boş geçilemez.." ),
    StringLength(200, ErrorMessage = "Kitap Adı en fazla 200 karakter olmalıdır..")]
    string Title,

    [Required(ErrorMessage = "Yazar Adı boş geçilemez.." ),
    StringLength(100, ErrorMessage = "Yazar adı en fazla 100 karakter olmalıdır.."),
    RegularExpression(@"^[^0-9]*$", ErrorMessage = "Yazar Adı rakam içeremez..")]
    string Author
);