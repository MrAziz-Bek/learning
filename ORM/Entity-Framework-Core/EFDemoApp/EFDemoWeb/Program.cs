using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();