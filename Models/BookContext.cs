using Microsoft.EntityFrameworkCore;

namespace dnc_bookservice.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base (options)
        {

        }

        public DbSet<Book> Books {get;set;}
    }
}