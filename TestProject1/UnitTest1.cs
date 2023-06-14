using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using books_app.Controllers;
using books_app.Data;
using books_app.Data.Services;
using my_books.Data.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    //[TestClass]
    public class TestBooksAppController
    {
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            var testBooks = GetTestBooks();
            var controller = new BooksController(testBooks);

            var result = controller.GetAllBooks() as List<Book>;
            Assert.AreEqual(testBooks.Count, result.Count());
        }

        public void GetBookById_ShouldReturnCorrectBook()
        {
            var testBooks = GetTestBooks();
            var controller = new BooksController(testBooks);

            var result = controller.GetBookById(4) as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks[3].Title, result.Content.Title);
        }

        private List<Book> GetTestBooks()
        {
            var testBooks = new List<Book>();
            
            testBooks.Add(testBooks.First());
            testBooks.Add(testBooks.Last());

            return testBooks;
        }
    }
}