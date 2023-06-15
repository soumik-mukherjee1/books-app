using books_app.Data.ViewModel;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace books_app.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;

        public BookService()
        {
            
        }

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public virtual List<Book> GetAllBooks() => _context.Books.ToList();

        public virtual Book GetBookById(int bookId) {
            //_context.Books.FirstOrDefault(n => n.Id == bookId);
            return _context.Books.FirstOrDefault(book => book.Id == bookId);
        } 

        public virtual Book UpdateBookById(int bookId,  BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public virtual void deleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
