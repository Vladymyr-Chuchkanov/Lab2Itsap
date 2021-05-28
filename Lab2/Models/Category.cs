using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
