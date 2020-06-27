using AutoMapper;
using Blogs.DAL;
using Blogs.DAL.Entities;
using Blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.Services.Themes
{
    public class ThemeService : IThemeService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ThemeService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public List<ThemeModel> SearchThemes()
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                IEnumerable<Theme> themes = unitOfWork.Themes.GetAllWithAuthorsAndRecords();
                return Mapper.Map<List<ThemeModel>>(themes.ToList());
            }
        }

        public void CreateTheme(ThemeCreateModel themeCreateModel, int userId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Theme theme = Mapper.Map<Theme>(themeCreateModel);
                theme.AuthorId = userId;
                unitOfWork.Themes.Create(theme);
            }
        }
    }
}
