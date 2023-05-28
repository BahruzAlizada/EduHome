using EduHome.DAL;
using EduHome.Helper;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public TeachersController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _db.Teachers.ToListAsync();
            return View(teachers);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (teacher.Name == null)
            {
                ModelState.AddModelError("Name", "Teacher name can not be null");
                return View();
            }
            #region Photo
            if (teacher.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }

            if (!teacher.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select image type");
                return View();
            }

            if (teacher.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "Max 256Kb");
                return View();
            }


            string folder = Path.Combine(_env.WebRootPath, "img", "teacher");
            teacher.Image =await teacher.Photo.SaveFileAsync(folder);

            #endregion

            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Teacher dbteacher = await _db.Teachers.FirstOrDefaultAsync(x=>x.Id==id);
            if(dbteacher == null)
            {
                return BadRequest();
            }
            return View(dbteacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Teacher teacher)
        {
            if (id == null)
            {
                return NotFound();
            }
            Teacher dbteacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbteacher == null)
            {
                return BadRequest();
            }
            
            dbteacher.Name= teacher.Name;
            dbteacher.Role = teacher.Role;
            dbteacher.Image=teacher.Image;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Teacher dbteacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbteacher == null)
            {
                return BadRequest();
            }

            if (dbteacher.IsDeactive)
            {
                dbteacher.IsDeactive = false;
            }
            else
            {
                dbteacher.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
