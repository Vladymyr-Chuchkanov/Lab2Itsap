using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class DBLab2Context : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountBook> AccountBooks { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public DBLab2Context(DbContextOptions<DBLab2Context> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

}
}
