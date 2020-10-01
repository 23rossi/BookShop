using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions
    <AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Query> Queries { get; set; }
    }
}
