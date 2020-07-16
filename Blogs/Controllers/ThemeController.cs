using System;
using System.Collections.Generic;
using Blogs.DAL.Entities;
using Blogs.Services.Themes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blogs.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeService _themeService;
        private readonly UserManager<User> _userManager;

        public ThemeController(IThemeService themeService, UserManager<User> userManager)
        {
            if (themeService == null)
                throw new ArgumentNullException(nameof(themeService));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _themeService = themeService;
            _userManager = userManager;
        }

        public IActionResult GetAllThemes()
        {
            try
            {
                List<ThemeModel> themes = _themeService.GetAllThemes();
                return PartialView("_AllThemes", themes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTheme(ThemeCreateModel theme)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                _themeService.CreateTheme(theme, user.Id);
                List<ThemeModel> themes = _themeService.GetAllThemes();
                return PartialView("_AllThemes", themes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}
