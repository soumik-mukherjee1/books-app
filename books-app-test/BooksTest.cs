using books_app.Controllers;
using books_app.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace books_app_test
{
    [TestClass]
    public class BooksTest
    {
        [TestMethod]
        public void TestGetBookById_ShouldReturnCorrectMethod()
        {
            var book = new Book
            {
                Id = 5,
                Title = "TestDescription",
                Description = "Great Book",
                IsRead = true,
                DateRead = DateTime.Now,
                Rate = 5,
                Author = "Soumik M",
                Genre = "Comedy",
                CoverUrl = "www.goog....",
                DateAdded = DateTime.Now.AddDays(-10),
            };

            var bookService = new Mock<BookService>();
            bookService.Setup(x => x.GetBookById(It.IsAny<int>())).Returns(book);

            var controller = new BooksController(bookService.Object);

            var getBookById = controller.GetBookById(5);

            Assert.IsNotNull(getBookById);
        }

        [TestMethod]
        public void TestGetAllBooks_ShouldReturnAllBooks()
        {
            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Book 1",
                },
                new Book{
                    Id = 2,
                    Title = "Book 2",
                },
            };

            var bookService = new Mock<BookService>();
            bookService.Setup(x => x.GetAllBooks()).Returns(books);

            var controller = new BooksController(bookService.Object);

            var result = controller.GetAllBooks() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var returnedBooks = result.Value as List<Book>;
            Assert.IsNotNull(returnedBooks);
            Assert.AreEqual(2, returnedBooks.Count);

            Assert.AreEqual("Book 1", returnedBooks[0].Title);
            Assert.AreEqual("Book 2", returnedBooks[1].Title);
        }
    }
}
