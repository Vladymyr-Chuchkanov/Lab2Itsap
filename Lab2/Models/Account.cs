using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class Account
    {

        public Account()
        {
            AccountBooks = new List<AccountBook>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        


        public virtual ICollection<AccountBook> AccountBooks { get; set; }
    }
}
