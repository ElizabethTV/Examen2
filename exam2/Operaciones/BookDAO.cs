using exam2.Context;
using exam2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Operaciones
{
    public class BookDAO
    {
        //Creamos nuestro objeto de tipo context
        public Examen2Context contexto = new Examen2Context();

        //Creamos un metodo para crear nuestro libro
        public bool newBook(int idAuthor, string title, int chapters, int pages, double price)
        {
            try
            {
                var author = contexto.Authors.Where(autor => autor.Id == idAuthor).FirstOrDefault();

                if(author != null)
                {
                    Book book = new Book();
                    book.IdAuthor = idAuthor;
                    book.Title = title;
                    book.Chapters = chapters;
                    book.Pages = pages;
                    book.Price = price;

                    contexto.Books.Add(book);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }

        //GET books
        public List<Book> getBooks()
        {
            var books = contexto.Books.ToList<Book>();
            return books;
        }

        //GET BOOK BY ID
        public Book getBook(int idBook)
        {
            var book = contexto.Books.Where(a => a.Id == idBook).FirstOrDefault();
            return book;
        }

        //GET BOOK WITH AUTHOR
        public List<BookAuthor> getBookAuthor()
        {
            var query = from book in contexto.Books
                        join author in contexto.Authors on book.IdAuthor
                equals author.Id
                        select new BookAuthor
                        {
                            titleBook = book.Title,
                            nameAuthor = author.Name,
                            chapters = book.Chapters,
                            pages = book.Pages,
                            price = book.Price
                        };
            return query.ToList();
        }

        //GET BOOK BY TITLE
        public BookAuthor getsearchBook(string titleBook)
        {
            var query = from book in contexto.Books
                        join author in contexto.Authors on book.IdAuthor
                equals author.Id where book.Title == titleBook 
                        select new BookAuthor
                        {
                            titleBook = book.Title,
                            nameAuthor = author.Name,
                            chapters = book.Chapters,
                            pages = book.Pages,
                            price = book.Price
                        };
            return query.FirstOrDefault();
        }
    }
}
