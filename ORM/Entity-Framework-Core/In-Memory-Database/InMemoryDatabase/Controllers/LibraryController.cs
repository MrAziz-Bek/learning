using InMemoryDatabase.Models;
using InMemoryDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InMemoryDatabase.Controllers;

public class LibraryController : Controller
{
    private readonly ILibraryRepository _repository;

    public LibraryController(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var model = _repository.Books.Include(b => b.Author);

        return View(model);
    }

    public IActionResult Create()
    {
        var austen = new Author { Name = "Jane Austen" };

        var emma = new Book { Title = "Emma", Author = austen, Year = 1815 };

        _repository.Add(emma);
        _repository.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}