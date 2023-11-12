using exam2.Operaciones;
using exam2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ApiWebExam2.Controllers
{
    [Route("api")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookDAO bookDAO = new BookDAO();

        //EndPoint para agregar nuevo libro
        [HttpPost("book")]
        public bool newBook([FromBody] Book book)
        {
            return bookDAO.newBook(book.IdAuthor, book.Title, book.Chapters, book.Pages, book.Price);
        }

        //EndPoint para obtener los libros
        [HttpGet("books")]
        public List<Book> getBooks()
        {
            return bookDAO.getBooks();
        }

        //EndPoint para obtener libro por id
        [HttpGet("book")]
        public Book getBook(int idBook)
        {
            return bookDAO.getBook(idBook);
        }

        //EndPoint para obtener libro con author
        [HttpGet("bookAuthor")]
        public List<BookAuthor> getBookAuthor()
        {
            return bookDAO.getBookAuthor();
        }

        //EndPoint para buscar un libro por su titulo
        [HttpGet("searchBook")]
        public BookAuthor getsearchBook(string titleBook)
        {
            return bookDAO.getsearchBook(titleBook);
        }
    }
}


