using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Core.Services.Interfaces;
using System.Threading.Tasks;
using BookStore.DataAccess.Entities;

namespace BookStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IBookServices _bookServices;
    public HomeController(ILogger<HomeController> logger, IBookServices bookServices)
    {
        _logger = logger;
        _bookServices = bookServices;
    }

    public async Task<IActionResult> Index()
    {
        var book = new Book()
        {
            Author = "Author1",
            CountExist = 10,
            DatePublishing = DateTime.Now,
            DemoFile = "demo.pdf",
            Description = "this is test description",
            Image = "test.jpg",
            IsDelete = false,
            Name = "name 1",
            Price = 123456789,
            Publisher = "HAssan",
            ShahbakCode = "1234567890123",
        };
        await _bookServices.AddBookAsync(book);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
