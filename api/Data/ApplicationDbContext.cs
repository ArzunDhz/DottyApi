using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        internal readonly object Stock;

        public ApplicationDbContext( DbContextOptions options  ) : base( options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData
                (
                new Stock { Id = 1, Name = "Apple Inc.", Purchase = 150, LastDiv = 2, Industry = "Technology", MarkCap = 200000000000 },
                new Stock { Id = 2, Name = "Alphabet Inc.", Purchase = 2500, LastDiv = 10, Industry = "Technology", MarkCap = 1500000000000 }
                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
