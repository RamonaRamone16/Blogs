using Blogs.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.DAL.EntitiesConfiguration
{
    public class RecordConfiguration : BaseEntityConfiguration<Record>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Record> builder)
        {
            builder.Property(r => r.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(r => r.Content)
                .HasMaxLength(2500)
                .IsRequired();

            builder.Property(r => r.PublishedDate)
                .IsRequired();

            builder.HasIndex(r => r.Title)
                .IsUnique(false);
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<Record> builder)
        {
            builder.HasOne(o => o.Author)
                .WithMany(o => o.Records)
                .HasForeignKey(o => o.AuthorId)
                .IsRequired();
        }
    }
}
