using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book", "library");

            builder.HasKey(book => book.Id);
            builder.HasIndex(book => book.Id);

            builder.HasOne(book => book.Genre).WithMany(p => p.Books)
                .HasForeignKey(book => book.GenreId)
                .HasConstraintName("book_genre_id_fkey")
                .IsRequired();

            builder.HasOne(book => book.Author).WithMany(p => p.Books)
                .HasForeignKey(book => book.AuthorId)
                .HasConstraintName("book_author_id_fkey")
                .IsRequired();

            builder.Property(book => book.Id).HasColumnName("id");
   
            builder.Property(book => book.ISBN).HasColumnName("isbn");
            builder.Property(book => book.Title).HasColumnName("title");
            builder.Property(book => book.Title).HasMaxLength(250);
            builder.Property(book => book.GenreId).HasColumnName("genre_id");
            builder.Property(book => book.Description).HasColumnName("description");
            builder.Property(book => book.AuthorId).HasColumnName("author_id");

            
        }
    }
}
