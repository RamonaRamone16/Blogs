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
                themes.ToList().Reverse();
                return Mapper.Map<List<ThemeModel>>(themes.ToList());
            }
        }

        public void CreateTheme(ThemeCreateModel themeCreateModel, int id)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Theme theme = Mapper.Map<Theme>(themeCreateModel);
                theme.AuthorId = id;
                unitOfWork.Themes.Create(theme);
            }
        }
    }
}
