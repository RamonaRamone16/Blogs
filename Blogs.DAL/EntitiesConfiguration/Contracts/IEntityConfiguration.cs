using Blogs.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Blogs.DAL.EntitiesConfiguration.Contracts
{
    public interface IEntityConfiguration<T> where T : class, IEntity
    {
        Action<EntityTypeBuilder<T>> ProvideConfigurationAction();
    }
}
