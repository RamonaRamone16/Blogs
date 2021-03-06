﻿using Blogs.DAL.EntitiesConfiguration.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blogs.DAL
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions _options;
        private readonly IEntityConfigurationContainer _entityConfigurationContainer;

        public ApplicationDbContextFactory(
            DbContextOptions options,
            IEntityConfigurationContainer entityConfigurationContainer
            )
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (entityConfigurationContainer == null)
                throw new ArgumentNullException(nameof(entityConfigurationContainer));

            _options = options;
            _entityConfigurationContainer = entityConfigurationContainer;
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(_options, _entityConfigurationContainer);
        }
    }
}
