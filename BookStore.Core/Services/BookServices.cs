using BookStore.Core.Services.Interfaces;
using BookStore.DataAccess.Context;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Services
{
    public class BookServices : IBookServices
    {
        private BookStoreContext _context;

        public BookServices(BookStoreContext context)
        {
            _context = context;
        }

        public async Task AddBookAsync(Book model)
        {
            await _context.Books.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
