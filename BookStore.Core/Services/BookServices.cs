using BookStore.Core.DTOs;
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

        public async Task<BookDetailViewModel?> GetBookDetailByIdAsync(int id)
        {
            return await _context.Books
                .Where(b => b.BookId == id)
                .Select(b => new BookDetailViewModel
                {
                    Author = b.Author,
                    ShahbakCode = b.ShahbakCode,
                    Publisher = b.Publisher,
                    Price = b.Price,
                    CountExist = b.CountExist,
                    DatePublishing = b.DatePublishing,
                    DemoFile = b.DemoFile,
                    Description = b.Description,
                    Image = b.Image,
                    Name = b.Name,
                }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetLatestBooksAsync()
        {
            return await _context.Books.OrderByDescending(b => b.DatePublishing).Take(10).ToListAsync();
            //ToDo Test
        }
    }
}
