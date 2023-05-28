using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NoticesController : Controller
    {
        private readonly AppDbContext _db;

        public NoticesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Notice> notices = await _db.Notices.ToListAsync();
            return View(notices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Notice notice)
        {
            notice.CreatedTime = DateTime.Today;

            await _db.Notices.AddAsync(notice);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Notice dbnotice = await _db.Notices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbnotice == null)
                return BadRequest();

            return View(dbnotice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Notice notice)
        {
            if (id == null)
                return NotFound();
            Notice dbnotice = await _db.Notices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbnotice == null)
                return BadRequest();

            dbnotice.Description = notice.Description;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Notice dbnotice = await _db.Notices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbnotice == null)
                return BadRequest();

            return View(dbnotice);
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Notice dbnotice = await _db.Notices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbnotice == null)
                return BadRequest();

            if (dbnotice.IsDeactive)
                dbnotice.IsDeactive = false;
            else
                dbnotice.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
