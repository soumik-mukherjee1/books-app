using books_app.Controllers;
using books_app.Data.Services;
using books_app.Data.ViewModel;
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

        [TestMethod]
        public void TestUpdateBookById_ShouldReturnUpdatedBook()
        {
            var updatedBookVM = new BookVM
            {
                Title = "Updated Book",
                Description = "Updated Description",
                IsRead = true,
                DateRead = DateTime.Now,
                Rate = 5,
                Genre = "Fiction",
                Author = "John Doe",
                CoverUrl = "http://example.com/cover.jpg"
            };

            var updatedBook = new Book
            {
                Id = 5,
                Title = updatedBookVM.Title,
                Description = updatedBookVM.Description,
                IsRead = updatedBookVM.IsRead,
                DateRead = updatedBookVM.IsRead ? updatedBookVM.DateRead.Value : null,
                Rate = updatedBookVM.IsRead ? updatedBookVM.Rate.Value : null,
                Genre = updatedBookVM.Genre,
                Author = updatedBookVM.Author,
                CoverUrl = updatedBookVM.CoverUrl
            };

            var bookService = new Mock<BookService>();
            bookService.Setup(x => x.UpdateBookById(It.IsAny<int>(), It.IsAny<BookVM>())).Returns(updatedBook);

            var controller = new BooksController(bookService.Object);

            var result = controller.UpdateBookById(5, updatedBookVM) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var updatedBookResult = result.Value as Book;
            Assert.IsNotNull(updatedBookResult);
            Assert.AreEqual(updatedBook.Id, updatedBookResult.Id);
        }

        [TestMethod]
        public void TestDeleteBookById_ShouldDeleteBook()
        {
            // Arrange
            var bookId = 5;

            var bookService = new Mock<BookService>();
            bookService.Setup(x => x.deleteBookById(It.IsAny<int>()));

            var controller = new BooksController(bookService.Object);

            // Act
            var result = controller.DeleteBookById(bookId) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            bookService.Verify(x => x.deleteBookById(bookId), Times.Once);
        }

    }
}
