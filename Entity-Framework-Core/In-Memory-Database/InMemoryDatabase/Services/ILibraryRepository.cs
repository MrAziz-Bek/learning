using InMemoryDatabase.Models;

namespace InMemoryDatabase.Services;

public interface ILibraryRepository
{
    IQueryable<Book> Books { get; }
    IQueryable<Author> Authors { get; }

    void Add<EntityType>(EntityType entity);
    void SaveChanges();
}