using BookStore.Core.Services.Interfaces;
using BookStore.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DataBase Context

builder.Services.AddDbContext<BookStoreContext>(option =>
{
    option.UseMySql(
        builder.Configuration.GetConnectionString("BookStoreConnection"),
        new MySqlServerVersion(new Version(8, 0, 41))
    );
});

#endregion

#region IoC

builder.Services.AddScoped<IBookServices, BookStore.Core.Services. BookServices>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
