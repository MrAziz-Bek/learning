using System.Text.Json;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFDemoWeb.Pages;

// Benefits of Entity Framework Core:
// 1. Faster development speed
// 2. You don't have to know SQL


// Benefits of Dapper:
// 1. Faster in production
// 2. Easier to work with for SQL developers
// 3. Designed for loose coupling

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly PeopleContext _db;

    public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet()
    {
        LoadSampleData();

        var people = _db.People
                    .Include(p => p.Addresses)
                    .Include(p => p.EmailAddresses)
                    //.Where(p => ApprovedAge(p.Age)) // it didn't work for EF Core because of c# codes, so don't call c# methods in EF query
                    .Where(p => p.Age >= 18 && p.Age <= 65)
                    .ToList();
    }

    private bool ApprovedAge(int age)
    {
        return (age >= 18 && age <= 65);
    }

    private void LoadSampleData()
    {
        if (_db.People.Count() == 0)
        {
            string file = System.IO.File.ReadAllText("generated.json");
            var people = JsonSerializer.Deserialize<List<Person>>(file);
            _db.AddRange(people);
            _db.SaveChanges();
        }
    }
}
