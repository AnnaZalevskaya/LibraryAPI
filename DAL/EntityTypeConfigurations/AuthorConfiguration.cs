using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("author", "library");

            builder.Property(author => author.Id).HasColumnName("id");
            builder.HasKey(author => author.Id);
            builder.HasIndex(author => author.Id);
            builder.Property(author => author.FullName).HasColumnName("full_name");
        }
    }
}