using Kutuphane.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Infrastructure.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
}