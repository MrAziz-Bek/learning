using Microsoft.EntityFrameworkCore;

namespace BookLibrary;

public class BooksContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public BooksContext() { }
    
    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options) {}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite("Filename=MyLocalLibrary.db");
    // }
}