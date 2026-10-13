using Kutuphane.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Domain.Entities;

public class BookCategory : BaseEntity
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}