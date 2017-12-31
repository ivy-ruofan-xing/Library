using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Library.Models
{
    public class BookDBContext : DbContext
    {
        public BookDBContext() : base("BookDBContext") { }

        public BookDBContext Create()
        {
            return new BookDBContext();
        }

        public DbSet<Book> Books { get; set; }
    }
}