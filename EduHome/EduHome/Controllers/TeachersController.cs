using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeachersController : Controller
    {
        private readonly AppDbContext _db;

        public TeachersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Teacher dbteacher = await _db.Teachers.Include(x => x.TeacherDetail).FirstOrDefaultAsync(x=>x.Id==id);
            if (dbteacher == null)
                return BadRequest();

            return View(dbteacher);
        }
    }
}
