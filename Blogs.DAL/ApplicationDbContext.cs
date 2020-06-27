using Blogs.DAL.EntitiesConfiguration.Contracts;
using Blogs.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogs.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public readonly IEntityConfigurationContainer _entityConfigurationContainer;

        public DbSet<Record> Records { get; set; }
        public DbSet<Theme> Themes { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationContainer entityConfigurationContainer) : base(options)
        {
            _entityConfigurationContainer = entityConfigurationContainer;

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(_entityConfigurationContainer.RecordConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationContainer.ThemeConfiguration.ProvideConfigurationAction());
        }
    }
}
