using Blogs.DAL.Entities;
using Blogs.DAL.EntitiesConfiguration.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Blogs.DAL.EntitiesConfiguration
{
    public class BaseEntityConfiguration<T> : IEntityConfiguration<T> where T : class, IEntity
    {
        public Action<EntityTypeBuilder<T>> ProvideConfigurationAction()
        {
            return EntityConfiguration;
        }

        private void EntityConfiguration(EntityTypeBuilder<T> builder)
        {
            ConfigureProperties(builder);
            ConfigurePrimaryKey(builder);
            ConfigureForeignKey(builder);
        }

        protected virtual void ConfigureProperties(EntityTypeBuilder<T> builder) { }
        protected virtual void ConfigurePrimaryKey(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }
        protected virtual void ConfigureForeignKey(EntityTypeBuilder<T> builder) { }
    }
}
