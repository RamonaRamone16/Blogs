using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blogs.DAL.Entities;
using Blogs.Models;
using Blogs.Services.Records;
using Blogs.Services.Themes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly UserManager<User> _userManager;
        private readonly IThemeService _themeService;

        public RecordController(IRecordService recordService, UserManager<User> userManager,
            IThemeService themeService)
        {
            if (recordService == null)
                throw new ArgumentNullException(nameof(recordService));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            if (themeService == null)
                throw new ArgumentNullException(nameof(themeService));
            _recordService = recordService;
            _userManager = userManager;
            _themeService = themeService;
        }

        public IActionResult Index(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    ViewBag.BadRequestMessage = "Theme Id is Null";
                    return View("BadRequest");
                }

                ThemeModel theme = _themeService.GetTheme(id.Value);

                return View(theme);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet]
        public IActionResult GetAllRecords(int themeId)
        {
            try
            {
                List<RecordModel> records = _recordService.SearchRecords(themeId);
                return PartialView("_AllRecords", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNewRecord(RecordModel record)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                _recordService.CreateRecord(record, user.Id);
                List<RecordModel> records = _recordService.SearchRecords(record.ThemeId);
                return PartialView("_AllRecords", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Like(int? recordId, int? themeId)
        {
            try
            {
                if (!recordId.HasValue)
                {
                    ViewBag.BadRequestMessage = "Record Id is Null";
                    return View("BadRequest");
                }
                if (!themeId.HasValue)
                {
                    ViewBag.BadRequestMessage = "Theme Id is Null";
                    return View("BadRequest");
                }

                _recordService.LikeRecord(recordId.Value);
                List<RecordModel> records = _recordService.SearchRecords(themeId.Value);
                return PartialView("_AllRecords", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
