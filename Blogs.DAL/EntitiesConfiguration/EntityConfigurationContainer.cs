using Blogs.DAL.Entities;
using Blogs.DAL.EntitiesConfiguration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.DAL.EntitiesConfiguration
{
    public class EntityConfigurationContainer : IEntityConfigurationContainer
    {
        public IEntityConfiguration<Record> RecordConfiguration { get; set; }

        public EntityConfigurationContainer()
        {
            RecordConfiguration = new RecordConfiguration();
        }

    }
}
