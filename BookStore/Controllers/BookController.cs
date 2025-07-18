using BookStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookServices _bookServices;

        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _bookServices.GetBookDetailByIdAsync(id);
            if (book is null)
                return NotFound();

            return View(book);
        }
    }
}
