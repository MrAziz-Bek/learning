using Microsoft.EntityFrameworkCore;
using InMemoryDatabase.Models;

namespace InMemoryDatabase.Data;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) { }
}