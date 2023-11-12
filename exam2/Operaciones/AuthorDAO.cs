using exam2.Context;
using exam2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Operaciones
{
    public class AuthorDAO
    {
        public Examen2Context contexto = new Examen2Context();

        //creamos un nuevo autor
        public bool newAuthor(string name)
        {
            try
            {
                var authorExist = contexto.Authors.Where(b => b.Name == name).FirstOrDefault();

                if (authorExist == null)
                {
                    Author author = new Author();
                    author.Name = name;

                    contexto.Authors.Add(author);
                    contexto.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                return false;
            }
        }

        //GET Autores
        public List<Author> getAuthors()
        {
            var authors = contexto.Authors.ToList<Author>();
            return authors;
        }
    }
}
