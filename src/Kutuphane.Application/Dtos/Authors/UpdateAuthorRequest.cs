using System.ComponentModel.DataAnnotations;
namespace Kutuphane.Application.Dtos.Authors;

public record UpdateAuthorRequest(
    [Required(ErrorMessage = "Yazar Adı boş geçilemez.." ),
    StringLength(100, ErrorMessage = "Yazar Adı en fazla 100 karakter olabilir..")]
    string Name,

    [Required(ErrorMessage = "Yazar Soyadı boş geçilemez.." ),
    StringLength(100, ErrorMessage = "Yazar Soyadı en fazla 100 karakter olabilir.."),
    RegularExpression(@"^[^0-9]*$", ErrorMessage = "Yazar Soyadı rakam içeremez..")]
    string Surname,

    [Required(ErrorMessage = "Yazar Uyruğu boş geçilemez.." ),
    StringLength(30, ErrorMessage = "Yazar Uyruğu en fazla 30 karakter olabilir..")]
    string Country,

    [StringLength(500, ErrorMessage = "Yazar Biyografisi en fazla 500 karakter olabilir..")]
    string? Biography,
    
    DateOnly? BirthDate,
    DateOnly? DeathDate,

    [Required(ErrorMessage = "Aktiflik durumu boş geçilemez..")]
    bool? IsActive,

    [StringLength(500, ErrorMessage = "Yazar Fotoğraf Bağlantısı en fazla 500 karakter olabilir..")]
    string? ImageUrl
);