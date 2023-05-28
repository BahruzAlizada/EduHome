using EduHome.DAL;
using EduHome.Helper;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class BlogsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public BlogsController(AppDbContext db,IWebHostEnvironment env)
        {
            _env = env;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _db.Blogs.ToListAsync();
            return View(blogs);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Blog blog)
        {
            blog.CreatedTime = DateTime.Today;

            #region BlogTitle
            bool isExist = await _db.Blogs.AnyAsync(x => x.Title == blog.Title);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This Title already exist ");
                return View();
            }

            if (blog.Title.Length <= 2)
            {
                ModelState.AddModelError("Title", "This is not Real Title");
                return View();
            }
            #endregion

            #region Photo
            if (blog.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }

            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Just select image type");
                return View();
            }

            if (blog.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "Max 256 Kb");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "img", "blog");
            blog.Image = await blog.Photo.SaveFileAsync(folder);
            #endregion
      
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Blog dbblog = await _db.Blogs.Include(x=>x.BlogDetail).FirstOrDefaultAsync(x => x.Id == id);
            if (dbblog == null)
                return BadRequest();

            return View(dbblog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id , Blog blog)
        {
            if (id == null)
                return NotFound();
            Blog dbblog = await _db.Blogs.Include(x=>x.BlogDetail).FirstOrDefaultAsync(x => x.Id == id);
            if (dbblog == null)
                return BadRequest();

            #region BlogTitle
            bool isExist = await _db.Blogs.AnyAsync(x => x.Title == blog.Title && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This Title already exist");
                return View();
            }
            #endregion

            #region Photo
            if (blog.Photo != null)
            {
                if (!blog.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select image type");
                    return View();
                }

                if (blog.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256 Kb");
                    return View();
                }

                string folder = Path.Combine(_env.WebRootPath, "img", "blog");
                blog.Image = await blog.Photo.SaveFileAsync(folder);
                string path = Path.Combine(_env.WebRootPath, folder, dbblog.Image);
                if(System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbblog.Image = blog.Image;
            }
            #endregion

            dbblog.BlogDetail.Description = blog.BlogDetail.Description;
            dbblog.Title = blog.Title;
            dbblog.By = blog.By;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Blog dbblog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbblog == null)
                return BadRequest();

            return View(dbblog);
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Blog dbblog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbblog == null)
                return BadRequest();

            if (dbblog.IsDeactive)
                dbblog.IsDeactive = false;
            else
                dbblog.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
