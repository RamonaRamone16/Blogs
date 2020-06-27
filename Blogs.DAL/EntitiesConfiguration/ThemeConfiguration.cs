using Blogs.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.DAL.EntitiesConfiguration
{
    public class ThemeConfiguration : BaseEntityConfiguration<Theme>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Theme> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Content)
                .HasMaxLength(2500)
                .IsRequired();

            builder.Property(t => t.PublishedDate)
                .IsRequired();

            builder.HasIndex(t => t.Title)
                .IsUnique(false);
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Theme> builder)
        {
            builder.HasOne(t => t.Author)
                .WithMany(a => a.Themes)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(t => t.Records)
                .WithOne(r => r.Theme)
                .HasForeignKey(r => r.ThemeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
