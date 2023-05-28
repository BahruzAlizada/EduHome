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
            decimal take = 6;
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
    }
}
