using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Core.Services.Interfaces;
using System.Threading.Tasks;

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
        return Json(await _bookServices.GetAllBooksAsync());
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
