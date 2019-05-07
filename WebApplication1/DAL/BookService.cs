using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebApplication1.DAL
{
    public class BookService : DbContext
    {

        public BookService() : base("BookService")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Code> Codes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
