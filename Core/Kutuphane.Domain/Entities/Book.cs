using Kutuphane.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Domain.Entities;

public class Book : BaseEntity
{
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Author { get; set; } = string.Empty;
}