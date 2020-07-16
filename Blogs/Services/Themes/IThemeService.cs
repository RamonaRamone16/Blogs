using Blogs.DAL.Entities;
using Blogs.Models;
using System.Collections.Generic;

namespace Blogs.Services.Themes
{
    public interface IThemeService
    {
        List<ThemeModel> GetAllThemes();
        void CreateTheme(ThemeCreateModel theme, int userId);
        ThemeModel GetTheme(int id);
    }
}
