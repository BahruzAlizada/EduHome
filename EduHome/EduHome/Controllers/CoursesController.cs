using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;

        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
