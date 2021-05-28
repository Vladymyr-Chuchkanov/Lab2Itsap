using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class Rating
    {
        public Rating()
        {
            AccountBooks = new List<AccountBook>();
        }
        public int Id { get; set; }
        public int mark { get; set; }

        public virtual ICollection<AccountBook> AccountBooks { get; set; }
    }
}
