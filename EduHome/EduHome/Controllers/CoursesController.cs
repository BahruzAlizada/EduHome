using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;

        public CoursesController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index(int page=1)
        {
            ViewBag.CoursesCount = await _db.Courses.Where(x => !x.IsDeactive).CountAsync();
            decimal take = 6;
            ViewBag.Take = (int)take;
            ViewBag.PageCount =Math.Ceiling((decimal)(await _db.Courses.Where(x=>!x.IsDeactive).CountAsync()/take));

            List<Course> course = await _db.Courses.Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).Skip((page-1)*6).Take((int)take).ToListAsync();
            return View(course);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Course dbcourse = await _db.Courses.Include(x => x.CourseDetail).FirstOrDefaultAsync(x => x.Id == id);
            if (dbcourse == null)
                return BadRequest();

            return View(dbcourse);
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Course dbcourse = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (dbcourse == null)
                return BadRequest();

            if (dbcourse.IsDeactive)
                dbcourse.IsDeactive = false;
            else
                dbcourse.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Courses");
        }
        #endregion

        #region Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            List<Course> course = new List<Course>(); 

            if (!string.IsNullOrEmpty(searchTerm))
                course = await _db.Courses.Where(x => x.Name.Contains(searchTerm)).ToListAsync();

            return PartialView("_courseSearchResult", course);
        }
        #endregion
    }
}
