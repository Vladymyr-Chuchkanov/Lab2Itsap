using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class Book
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int YearEdition { get; set; }
        public int RatingSum { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }




    }
}
