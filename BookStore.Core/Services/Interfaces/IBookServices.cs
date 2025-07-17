using BookStore.DataAccess.Entities;

namespace BookStore.Core.Services.Interfaces
{
   public interface IBookServices
    {
        public Task AddBookAsync(Book model);

        public Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
