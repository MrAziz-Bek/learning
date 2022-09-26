using BookLibrary;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksContext>(options => 
    options
        // .UseLazyLoadingProxies()
        .UseSqlite(builder.Configuration.GetConnectionString("BooksLibrary:SQLite")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Books}/{action=Index}/{id?}"
    );
});

app.Run();
