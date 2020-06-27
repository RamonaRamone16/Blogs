using Blogs.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.DAL.EntitiesConfiguration
{
    class UserConfiguration : BaseEntityConfiguration<User>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<User> builder)
        {
        }

        protected override void ConfigureForeignKey(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Records)
                .WithOne(r => r.Author)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(u => u.Themes)
                .WithOne(t => t.Author)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
