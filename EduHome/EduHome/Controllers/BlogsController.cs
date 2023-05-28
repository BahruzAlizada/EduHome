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
    public class BlogsController : Controller
    {
        private readonly AppDbContext _db;

        public BlogsController(AppDbContext db)
        {
            _db = db;   
        }

        #region Index
        public async Task<IActionResult> Index(int page = 1)
        {
            decimal take = 9;
            ViewBag.PageCount = Math.Ceiling((decimal)(await _db.Blogs.Where(x => !x.IsDeactive).CountAsync() / take));

            List<Blog> blogs = await _db.Blogs.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Skip((page - 1) * 9).Take((int)take).ToListAsync();
            return View(blogs);
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Blog blog = await _db.Blogs.Include(x => x.BlogDetail).FirstOrDefaultAsync(x => x.Id == id);
            if (blog == null)
                return BadRequest();

            return View(blog);
        }
        #endregion


    }
}
