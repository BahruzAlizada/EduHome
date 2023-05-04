using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id==null)
                return NotFound();
            Course dbcourse = await _db.Courses.Include(x=>x.CourseDetail).FirstOrDefaultAsync(x => x.Id == id);
            if (dbcourse == null)
                return BadRequest();

            return View(dbcourse);
        }
    }
}
