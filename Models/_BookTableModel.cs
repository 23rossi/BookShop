using System.Collections.Generic;
using BookShop.DataAccess;
using System.Linq;
using System.Data;

namespace BookShop.Models
{
    public class _BookTableModel
    {
        //list of books
        public IList<Query> Book { get; set; }
        private BookShop.DataAccess.AppDbContext db;
        public _BookTableModel(BookShop.DataAccess.AppDbContext DB)
        {
            db = DB;
            //init data
            GetTableData();
        }

        //Get book on query base on form query
        public void GetTableData(Query bookQuery = null)
        {
            Book = (from author in db.Authors join book in db.Books on author.AuthorID equals book.AuthorID select new Query() { BookName = book.Name, AuthorName = author.Name, QueryText = null }).ToList();
            if (bookQuery?.BookName?.Count() > 0)
            {
                Book = (from book in Book
                        where book.BookName.ToLower().Contains(bookQuery.BookName.ToLower())
                        select book).ToList();
            }
            if (bookQuery?.AuthorName?.Count() > 0)
            {
                Book = (from book in Book
                        where book.AuthorName.ToLower().Contains(bookQuery.AuthorName.ToLower())
                        select book).ToList();
            }
        }
    }
}
