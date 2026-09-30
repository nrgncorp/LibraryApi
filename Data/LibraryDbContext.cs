using KutuphaneApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneApi.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}