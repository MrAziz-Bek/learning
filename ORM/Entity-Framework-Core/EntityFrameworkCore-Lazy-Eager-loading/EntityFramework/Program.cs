using System;
using System.Linq;
using BookLibrary;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


        var options = new DbContextOptionsBuilder<BooksContext>()
            .UseSqlite(config.GetConnectionString("BooksLibrary:SQLite"))
            .Options;

        using var db = new BooksContext(options);

        db.Database.EnsureCreated();

        // var authors = CreateFakeData(); // first uncomment these(3) lines for creating fake datas and load them to db, and comment them again

        // db.Authors.AddRange(authors);
        // db.SaveChanges();

        var recentBooks = from b in db.Books where b.YearOfPublication > 1900 select b;

        foreach (var book in recentBooks.Include(b => b.Author))
        {
            Console.WriteLine($"{book} is by {book.Author}");
        }
    }
}