using BookStore.Core.Services;
using BookStore.DataAccess.Context;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace BookStore.Test
{
    public class BookServicesTest
    {
        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book
                {
                    Name = "Test Book",
                    CountExist = 10,
                    DemoFile = "test.pdf",
                    Description = "This is a test book description.",
                    Image = "test.jpg",
                    Publisher = "Test Publisher",
                    DatePublishing = DateTime.Now,
                    Author = "Test Author",
                    Price = 9,
                    IsDelete = false
                }
            };

            var mockSet = books.AsQueryable().BuildMockDbSet();

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            var service = new BookServices(mockContext.Object);

            // Act
            var result = await service.GetAllBooksAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Book", result.ToList()[0].Name);
        }

        [Fact]
        public async Task AddBookAsync_ShouldAddOneBook()
        {
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            //Act
            var service = new BookServices(mockContext.Object);
            await service.AddBookAsync(new Book()
            {   
                Name = "Test Book",
                CountExist = 10,
                DemoFile = "test.pdf",
                Description = "This is a test book description.",
                Image = "test.jpg",
                Publisher = "Test Publisher",
                DatePublishing = DateTime.Now,
                Author = "Test Author",
                Price = 9,
                IsDelete = false
            });

            //Assert
            mockSet.Verify(m => m.AddAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()), Times.Once);
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}