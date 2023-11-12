using exam2.Operaciones;
using exam2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ApiWebExam2.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorDAO authorDAO = new AuthorDAO();

        //EndPoint para agregar nuevo autor
        [HttpPost("author")]
        public bool newAuthor([FromBody] Author author)
        {
            return authorDAO.newAuthor(author.Name);
        }

        //EndPoint para obtener autores
        [HttpGet("authors")]
        public List<Author> getAuthors()
        {
            return authorDAO.getAuthors();
        }
    }
}
