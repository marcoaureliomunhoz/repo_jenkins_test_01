using Microsoft.EntityFrameworkCore;

namespace biblio_api
{
    public class BiblioDbContext : DbContext
    {
        public BiblioDbContext(DbContextOptions<BiblioDbContext> options) : base(options)
        {
            
        }

        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Editora>().ToTable(nameof(Editora));
        }
    }
}