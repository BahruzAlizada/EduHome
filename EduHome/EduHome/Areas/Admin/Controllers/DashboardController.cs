using EduHome.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;

        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.BlogsCount = await _db.Blogs.Where(x => !x.IsDeactive).CountAsync();
            ViewBag.DeactiveBlogsCount = await _db.Blogs.Where(x => x.IsDeactive).CountAsync();

            ViewBag.CoursesCount = await _db.Courses.Where(x => !x.IsDeactive).CountAsync();
            ViewBag.DeactiveCoursesCount = await _db.Courses.Where(x => x.IsDeactive).CountAsync();
            return View();
        }
    }
}
