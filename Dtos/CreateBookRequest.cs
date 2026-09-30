using System.ComponentModel.DataAnnotations;
namespace KutuphaneApi.Dtos;

public record CreateBookRequest(
    [Required, StringLength(200)] string Title,
    [Required, StringLength(100)] string Author
);