using InMemoryDatabase.Models;
using InMemoryDatabase.Services;

namespace InMemoryDatabase.Test.Mocks;

public class MockRepository : ILibraryRepository
{
    private readonly List<Book> _books = new List<Book>();
    private readonly List<Author> _authors = new List<Author>();

    public IQueryable<Book> Books => _books.AsQueryable();

    public IQueryable<Author> Authors => _authors.AsQueryable();

    public void Add<EntityType>(EntityType entity)
    {
        switch (entity)
        {
            case Book book:
                _books.Add(book);
                break;
            case Author author:
                _authors.Add(author);
                break;
        }
    }

    public void SaveChanges()
    {
        
    }
}