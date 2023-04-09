using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public BlogViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Blog> blogs = new List<Blog>();
            if (take == 0)
            {
                blogs = await _db.Blogs.OrderByDescending(x=>x.Id).ToListAsync();
            }
            else
            {
                blogs = await _db.Blogs.OrderByDescending(x => x.Id).Take(take).ToListAsync();
            }
              
          
            return View(blogs);
        }

    }
}
