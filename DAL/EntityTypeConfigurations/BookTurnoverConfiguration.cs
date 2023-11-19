using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations
{
    public class BookTurnoverConfiguration : IEntityTypeConfiguration<BookTurnover>
    {
        public void Configure(EntityTypeBuilder<BookTurnover> builder)
        {
            builder.ToTable("book_turnover", "library");

            builder.Property(turnover => turnover.Id).HasColumnName("id");
            builder.HasKey(turnover => turnover.Id);
            builder.HasIndex(turnover => turnover.Id);

            builder.HasOne(turnover => turnover.Book).WithMany(b => b.TakenBooks)
                .HasForeignKey(turnover => turnover.BookId)
                .HasConstraintName("book_turnover_book_id_fkey");

            builder.Property(turnover => turnover.UserId).HasColumnName("user_id");
            builder.Property(turnover => turnover.BookId).HasColumnName("book_id");
            builder.Property(turnover => turnover.TakenTime).HasColumnName("taken_time");
            builder.Property(turnover => turnover.ReturnedTime).HasColumnName("returned_time");
            builder.Property(turnover => turnover.IsTaken).HasColumnName("is_taken");   
        }
    }
}