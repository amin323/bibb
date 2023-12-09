using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblotek.models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Biblotek.Data
{
    public class Context : DbContext
    {
        public DbSet<Borrower> borrowers{ get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }

        // Add other DbSet properties for your entities (Authors, BookLoan, etc.) as needed

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;
                                        Database=Biblotek;
                                        TrustServerCertificate=True;
                                        User Id=bib2;
                                        Password=Biblotek");
        }
    }
}

