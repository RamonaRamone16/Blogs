using Blogs.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.DAL.EntitiesConfiguration
{
    public class RecordConfiguration : BaseEntityConfiguration<Record>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Record> builder)
        {
            builder.Property(r => r.Content)
                .HasMaxLength(2500)
                .IsRequired();

            builder.Property(r => r.PublishedDate)
                .IsRequired();
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Record> builder)
        {
            builder.HasOne(o => o.Author)
                .WithMany(o => o.Records)
                .HasForeignKey(o => o.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(o => o.Theme)
                .WithMany(o => o.Records)
                .HasForeignKey(o => o.ThemeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
