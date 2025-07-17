using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        public BookStoreContext()
        {
        }

        #region Book

        public virtual DbSet<Book> Books { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDelete);
            base.OnModelCreating(modelBuilder);
        }
    }
}
