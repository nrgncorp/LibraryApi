using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Surname { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Biography { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public DateOnly? DeathDate { get; set; }
    [MaxLength(500)]
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}