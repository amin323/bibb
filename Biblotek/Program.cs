
using Microsoft.EntityFrameworkCore;

using Biblotek.models;
using System.Data;
using Biblotek.Data;


namespace Biblotek
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            DataAccess dataAccess = new DataAccess();

            //dataAccess.Seed();

            //dataAccess.BorrowBook(2,2);
            //dataAccess.CreateAuthor("dsd","sdsd");
            //dataAccess.CreateBook("2003",4,3.5);
            //dataAccess.CreateBorrower("sds","sds");
            //dataAccess.RemoveAuthor(2);
            //dataAccess.RemoveBook(1);

            //dataAccess.RemoveBorrower(2);
            //dataAccess.AddAuthortobook(4, 1);
            //dataAccess.MarkBookAsNotLoaned(2);



        }

    }


}


