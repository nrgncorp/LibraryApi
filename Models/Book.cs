using System.ComponentModel.DataAnnotations;

namespace KutuphaneApi.Models;

public class Book
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Author { get; set; } = string.Empty;
}