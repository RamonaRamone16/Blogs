using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blogs.DAL.Entities;
using Blogs.Models;
using Blogs.Services.Records;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly UserManager<User> _userManager;

        public RecordController(IRecordService recordService, UserManager<User> userManager)
        {
            if (recordService == null)
                throw new ArgumentNullException(nameof(recordService));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _recordService = recordService;
            _userManager = userManager;
        }

        public IActionResult Index(RecordFilterModel model)
        {
            try
            {
                model.Records = _recordService.SearchRecords(model);


                return View(model);
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
        public async Task<IActionResult> CreateRecord(RecordCreateModel record)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                _recordService.CreateRecord(record, user.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
