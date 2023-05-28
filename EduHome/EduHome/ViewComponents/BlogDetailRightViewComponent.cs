using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class BlogDetailRightViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public BlogDetailRightViewComponent (AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Blog> blogs = await _db.Blogs.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(3).ToListAsync();

            return View(blogs);
        }
    }
}
