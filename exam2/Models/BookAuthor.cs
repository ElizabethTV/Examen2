using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2.Models
{
    public class BookAuthor
    {
        public string titleBook { get; set; } = null;
        public string nameAuthor { get; set; } = null;
        public int chapters { get; set; }
        public int pages { get; set; }
        public double price { get; set; }
    }
}
