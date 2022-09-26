using System.Data.Entity;

namespace EF6CodeFirst;

public class BooksContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}