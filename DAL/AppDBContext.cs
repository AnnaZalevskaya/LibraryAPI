using DAL.Entities;
using DAL.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL
{
    public class AppDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; } 
        public DbSet<BookTurnover> BookTurnovers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(new BookConfiguration().Configure);
            builder.Entity<BookTurnover>(new BookTurnoverConfiguration().Configure);
            builder.Entity<Genre>(new GenreConfiguration().Configure);
            builder.Entity<Author>(new AuthorConfiguration().Configure);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder); 
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync();
        }
    }
}
