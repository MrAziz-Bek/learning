using System;
using System.Collections.Generic;
using System.Linq;
using EF6CodeFirst;

namespace EF6Console;

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
        // unforntunatelly these lines(40-45) may show exception because of some platforms(for example Mac OS) didn't support these
        using var db = new BooksContext();

        var authors = CreateFakeData();

        db.Authors.AddRange(authors);
        db.SaveChanges();
    }
}