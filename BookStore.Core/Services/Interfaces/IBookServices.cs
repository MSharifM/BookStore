using BookStore.Core.DTOs;
using BookStore.DataAccess.Entities;

namespace BookStore.Core.Services.Interfaces
{
   public interface IBookServices
    {
        public Task AddBookAsync(Book model);

        public Task<IEnumerable<Book>> GetAllBooksAsync();

        public Task<BookDetailViewModel> GetBookDetailByIdAsync(int id);

        public Task<IEnumerable<Book>> GetLatestBooksAsync();
    }
}
