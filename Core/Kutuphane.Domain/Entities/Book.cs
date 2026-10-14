using Kutuphane.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Domain.Entities;

public class Book : BaseEntity
{
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int CategoryId { get; set; }
    public BookCategory BookCategory { get; set; } = null!;
}