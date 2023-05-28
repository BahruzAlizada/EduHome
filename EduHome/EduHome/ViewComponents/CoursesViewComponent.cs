using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class CoursesViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public CoursesViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        {     
                List<Course> courses = courses = await _db.Courses.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(3).ToListAsync();
                return View(courses); 
        }

    }
}
