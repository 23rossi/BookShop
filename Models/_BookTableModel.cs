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
        //book status at the stock
        public string BookStatus { get; set; }
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
            //if has been send request through form, then show DB status
            if (bookQuery != null)
            {
                BookStatus = SaveQuery(Book, bookQuery.QueryText);
            }
        }
        //try to find book and get status
        public string SaveQuery(IList<Query> book, string QueryText)
        {
            if (book.Count() == 1)
            {
                Query record = new Query();
                record = book[0];
                record.QueryText = QueryText;

                if (IsBooked(record)) return "Book has been already booked!";

                db.Queries.Add(record);
                db.SaveChanges();

                return "Book has been booked!";
            }
            if (book.Count() > 1)
            {
                return "More books chosen!";
            }
            return "Book not found!";
        }
        //get book status from DB
        public bool IsBooked(Query book)
        {
            return (from b in db.Queries
                    where b.BookName.Contains(book.BookName) && b.AuthorName.Contains(book.AuthorName)
                    select b).Count() > 0;
        }
    }
}
