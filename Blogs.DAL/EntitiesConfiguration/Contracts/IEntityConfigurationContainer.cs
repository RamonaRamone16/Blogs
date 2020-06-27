using Blogs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.DAL.EntitiesConfiguration.Contracts
{
    public interface IEntityConfigurationContainer
    {
        IEntityConfiguration<Record> RecordConfiguration { get; }
        IEntityConfiguration<Theme> ThemeConfiguration { get; }
    }
}
