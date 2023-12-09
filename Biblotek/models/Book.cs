using System;
using System.ComponentModel.DataAnnotations;
using Biblotek.models;


namespace Biblotek.models
{
    public class Book
    {

        public int BookID { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double? Grade { get; set; }

        public Borrower? borrower { get; set; }
        
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }


        public ICollection<Author> Authors { get; set; } = new List<Author>();


    }
}