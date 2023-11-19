using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre", "library");

            builder.Property(genre => genre.Id).HasColumnName("id");
            builder.HasKey(genre => genre.Id);
            builder.HasIndex(genre => genre.Id);
            builder.Property(genre => genre.Name).HasColumnName("name");
        }
    }
}
