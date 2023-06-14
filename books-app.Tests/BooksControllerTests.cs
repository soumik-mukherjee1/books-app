using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MyBooksApp.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        private BooksController _controller;
        private Mock<BookService> _bookServiceMock;

        [SetUp]
        public void Setup()
        {
            _bookServiceMock = new Mock<BookService>();
            _controller = new BooksController(_bookServiceMock.Object);
        }

        [Test]
        public void GetAllBooks_ReturnsOkResult()
        {
            // Arrange
            var expectedBooks = new List<Book>(); // Create a list of expected books

            // Mock the behavior of the BookService's GetAllBooks method to return the expected books
            _bookServiceMock.Setup(service => service.GetAllBooks()).Returns(expectedBooks);

            // Act
            var result = _controller.GetAllBooks();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result); // Assert that the result is an OkObjectResult
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedBooks, okResult.Value); // Assert that the returned value matches the expected books
        }

        [Test]
        public void GetBookById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var expectedBookId = 1;
            var expectedBook = new Book { Id = expectedBookId }; // Create a book with the expected id

            // Mock the behavior of the BookService's GetBookById method to return the expected book
            _bookServiceMock.Setup(service => service.GetBookById(expectedBookId)).Returns(expectedBook);

            // Act
            var result = _controller.GetBookById(expectedBookId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result); // Assert that the result is an OkObjectResult
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedBook, okResult.Value); // Assert that the returned value matches the expected book
        }

        [Test]
        public void AddBook_ValidBook_ReturnsOkResult()
        {
            // Arrange
            var bookToAdd = new BookVM { Title = "Test Book", Author = "Test Author" };

            // Act
            var result = _controller.AddBook(bookToAdd);

            // Assert
            Assert.IsInstanceOf<OkResult>(result); // Assert that the result is an OkResult
        }

        [Test]
        public void UpdateBookById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var expectedBookId = 1;
            var bookToUpdate = new BookVM { Title = "Updated Book", Author = "Updated Author" };
            var expectedUpdatedBook = new Book { Id = expectedBookId, Title = "Updated Book", Author = "Updated Author" };

            // Mock the behavior of the BookService's UpdateBookById method to return the expected updated book
            _bookServiceMock.Setup(service => service.UpdateBookById(expectedBookId, bookToUpdate)).Returns(expectedUpdatedBook);

            // Act
            var result = _controller.UpdateBookById(expectedBookId, bookToUpdate);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result); // Assert that the result is an OkObjectResult
            var okResult = result as OkObjectResult;
            Assert.AreEqual(expectedUpdatedBook, okResult.Value); // Assert that the returned value matches the expected updated book
        }

        [Test]
        public void DeleteBookById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var expectedBookId = 1;

            // Act
            var result = _controller.DeleteBookById(expectedBookId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result); // Assert that the result is an OkResult
        }
    }
}
