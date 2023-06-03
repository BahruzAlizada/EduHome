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
	public class ChartsController : Controller
	{
		private readonly AppDbContext _db;

        public ChartsController(AppDbContext db)
        {
			_db = db;
        }

		#region Index
		public async Task<IActionResult> Index()
		{
			#region BlogsChart
			ViewBag.BlogsCount = await _db.Blogs.Where(x => !x.IsDeactive).CountAsync();
			ViewBag.DeactiveBlogsCount = await _db.Blogs.Where(x => x.IsDeactive).CountAsync();
			#endregion

			#region CoursesChart
			ViewBag.CoursesCount = await _db.Courses.Where(x => !x.IsDeactive).CountAsync();
			ViewBag.DeactiveCoursesCount = await _db.Courses.Where(x => x.IsDeactive).CountAsync();
			#endregion

			#region PositionChart
			ViewBag.DrectorCount = await _db.Employees.Include(x => x.Position).Where(x => x.Position.Id == 1).CountAsync();
			ViewBag.ManagerCount = await _db.Employees.Include(x => x.Position).Where(x => x.Position.Id == 2).CountAsync();
			ViewBag.TeacherCount = await _db.Teachers.Where(x => !x.IsDeactive).CountAsync();
			#endregion

			return View();
		}
		#endregion
	}
}
