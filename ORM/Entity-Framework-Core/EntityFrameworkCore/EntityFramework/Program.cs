using System.Linq;
//using BookLibrary;
using DBFirstLibrary;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

class Program
{
    static IEnumerable<Author> CreateFakeData()
    {
        var authors = new List<Author>
        {
            new Author
            {
                Name = "Jane Austen", Books = new List<Book>
                {
                    new Book {Title = "Emma", YearOfPublication = 1815},
                    new Book {Title = "Persuasion", YearOfPublication = 1818},
                    new Book {Title = "Mansfield Park", YearOfPublication = 1814}
                }
            },
            new Author
            {
                Name = "Ian Fleming", Books = new List<Book>
                {
                    new Book {Title = "Dr No", YearOfPublication = 1958},
                    new Book {Title = "Goldfinger", YearOfPublication = 1959},
                    new Book {Title = "From Russia with Love", YearOfPublication = 1957}
                }
            }
        };

        return authors;
    }

    static void Main()
    {
        var options = new DbContextOptionsBuilder<MyLocalLibraryContext>()
                            .UseSqlite("Filename=MyLocalLibrary.db")
                            .Options;

        using var db = new MyLocalLibraryContext(options);

        db.Database.EnsureCreated();

        //var authors = CreateFakeData(); // first uncomment these(3) lines for creating fake datas and load them to db, and comment them again

        //db.Authors.AddRange(authors);
        //db.SaveChanges();

        var recentBooks = from b in db.Books where b.YearOfPublication > 1900 select b;

        foreach (var book in recentBooks.Include(b => b.Author))
        {
           Console.WriteLine($"{book} is by {book.Author}");
        }
    }
}