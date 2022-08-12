using BookTrackingWebLibrary;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingWebData.Data
{
    public class BookTrackingWebContext : DbContext
    {
        public BookTrackingWebContext(DbContextOptions<BookTrackingWebContext> bookTrackingContext)
         : base(bookTrackingContext)
        { }

        //Creating database context to specify entities that are included in model

        public DbSet<CategoryType> CategoryTypies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookQuote> BookQuotes { get; set; }
        public DbSet<BookReadTrack> BookReadTracks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoryType>().ToTable("CategoryType");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<BookQuote>().ToTable("BookQuote");
            modelBuilder.Entity<BookReadTrack>().ToTable("BookReadTrack");

        }
    }
}

