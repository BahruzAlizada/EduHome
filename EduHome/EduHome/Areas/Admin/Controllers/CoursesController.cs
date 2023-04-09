using EduHome.DAL;
using EduHome.Helper;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public CoursesController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _db.Courses.ToListAsync();
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Course course)
        {
            bool isExist = await _db.Courses.AnyAsync(x => x.Name == course.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This Course already exist !");
                return View();
            }
            #region Photo
            if (course.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }

            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select image type");
                return View();
            }

            if (course.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "max 256Kb");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "img", "course");
            course.Image = await course.Photo.SaveFileAsync(folder);
            #endregion

            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Course dbcourse = await _db.Courses.FirstOrDefaultAsync(x=>x.Id == id);
            if (dbcourse == null)
            {
                return BadRequest();
            }

            return View(dbcourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Course course)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course dbcourse = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (dbcourse == null)
            {
                return BadRequest();
            }

            bool isExist = await _db.Courses.AnyAsync(x=>x.Name== course.Name && x.Id != id);
            if(isExist)
            {
                ModelState.AddModelError("Name", "This Course already exist !");
                return View();
            }

            #region Photo
            if (course.Photo != null)
            {
                if (!course.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Please select image type");
                    return View();
                }

                if (course.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256Kb");
                    return View();
                }



                string folder = Path.Combine(_env.WebRootPath, "img", "course");
                course.Image = await course.Photo.SaveFileAsync(folder);
                string path = Path.Combine(_env.WebRootPath, folder, dbcourse.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                dbcourse.Image = course.Image;
            }
            #endregion

            dbcourse.Name = course.Name;
            dbcourse.Description=course.Description;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course dbcourse = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if(dbcourse== null)
            {
                return BadRequest();
            }
            return View(dbcourse);
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course dbcourse = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (dbcourse == null)
            {
                return BadRequest();
            }

            if (dbcourse.IsDeactive)
            {
                dbcourse.IsDeactive = false;
            }
            else
            {
                dbcourse.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
