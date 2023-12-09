using Biblotek.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace Biblotek.Data
{
    public class DataAccess
    {
        Context context = new Context();

        

        public void Seed()
        {
            var author1 = new Author { Name = "amin", LastName = "allehom" };
            var author2 = new Author { Name = "karim", LastName = "benzema" };
            var author3 = new Author { Name = "jon", LastName = "jones" };

            var book1 = new Book { Title = "48 law", Year = 2020, Grade = 1.5 };
            var book2 = new Book { Title = "walking dead", Year = 2021, Grade = 4.0 };
            var book3 = new Book { Title = "meditations", Year = 2022, Grade = 3.3 };

            var borrower1 = new Borrower { FirstName = "mcgregor", LastName = "connor" };
            var borrower2 = new Borrower { FirstName = "becho", LastName = "begre" };
            var borrower3 = new Borrower { FirstName = "mane", LastName = "sadio" };

            context.borrowers.Add(borrower1);
            context.borrowers.Add(borrower2);
            context.borrowers.Add(borrower3);


            book1.Authors.Add(author1);
            book2.Authors.Add(author2);
            book3.Authors.Add(author3);

            context.books.Add(book1);
            context.books.Add(book2);
            context.books.Add(book3);

            context.SaveChanges();
        }


        public void AddAuthortobook(int bookId, int authorId)
        {
            using (var context = new Context())
            {
                var book = context.books.SingleOrDefault(p => p.BookID == bookId);
                var author = context.authors.SingleOrDefault(p => p.AuthorId == authorId);

                if (book != null && author != null)
                {
                    book.Authors.Add(author);
                    author.Books.Add(book);
                    context.SaveChanges();
                }

                else
                {
                    return;
                }
            }
        }

        public void MarkBookAsNotLoaned(int bookId)
        {
            using (var context = new Context())
            {
                var book = context.books.Include(b => b.borrower).FirstOrDefault(b => b.BookID == bookId);

                if (book != null)
                {
                    book.LoanDate = DateTime.MinValue;
                    book.ReturnDate = DateTime.MinValue;

                  

                    book.borrower = null;
                    

                    context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
        }

        public Author CreateAuthor(string firstName, string lastName)
        {
            var newAuthor = new Author { Name = firstName, LastName = lastName };
            context.authors.Add(newAuthor);
            context.SaveChanges();
            return newAuthor;
        }


        public Book CreateBook(string title, int year, double grade)
        {
            var newBook = new Book { Title = title, Year = year, Grade = grade };
            context.books.Add(newBook);
            context.SaveChanges();
            return newBook;
        }


        public Borrower CreateBorrower(string firstName, string lastName)
        {
            var newBorrower = new Borrower { FirstName = firstName, LastName = lastName };
            context.borrowers.Add(newBorrower);
            context.SaveChanges();
            return newBorrower;
        }



        public bool BorrowBook(int bookId, int borrowerId)
        {
            var book = context.books.SingleOrDefault(b => b.BookID == bookId);
            var borrower = context.borrowers.SingleOrDefault(b => b.borrowerId == borrowerId);

            if (book != null && borrower != null)
            {
                book.LoanDate = DateTime.Now;
                book.ReturnDate = DateTime.Now.AddDays(14);
                book.borrower = borrower;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        
        public void RemoveBorrower( int BorrowerId)
        {
            var Borrower = context.borrowers.SingleOrDefault(b => b.borrowerId== BorrowerId);
            if (Borrower != null)
            {
                context.borrowers.Remove(Borrower);
                context.SaveChanges();
            }
        }



        public void RemoveBook(int BookID)
        {
            var Book = context.books.SingleOrDefault(b => b.BookID == BookID);
            if (Book != null)
            {
                context.books.Remove(Book);
                context.SaveChanges();
            }
        }



        public void RemoveAuthor(int AuthorID)
        {
            var Author = context.authors.SingleOrDefault(b => b.AuthorId == AuthorID);
            if (Author != null)
            {
                context.authors.Remove(Author);
                context.SaveChanges();
            }
        }
        

       
    }
}
