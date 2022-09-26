using Microsoft.EntityFrameworkCore;

namespace BookLibrary;

public class BooksContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options) { }
}