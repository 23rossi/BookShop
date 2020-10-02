using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShop.DataAccess;

namespace BookShop.Pages
{
    public class BookTableModel : PageModel
    {
        private readonly BookShop.DataAccess.AppDbContext db;

        public BookTableModel(BookShop.DataAccess.AppDbContext DB)
        {
            db = DB;
        }

        public IList<Book> Book { get;set; }
        public IList<Author> Author { get; set; }

        public async Task OnGetAsync()
        {
            var listBook = await (from book in db.Books join author in db.Authors on book.BookID equals author.BookID select new { Book = book.Name, Author = author.Name }).ToListAsync();
        }
    }
}
