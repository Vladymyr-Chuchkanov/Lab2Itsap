using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class AccountBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AccountId { get; set; }
        public int RatingId { get; set; }
        public string Comment { get; set; }

        public virtual Account Account{get;set;}
        public virtual Book Book { get; set; }
        public virtual Rating Rating { get; set; }


    }
}
