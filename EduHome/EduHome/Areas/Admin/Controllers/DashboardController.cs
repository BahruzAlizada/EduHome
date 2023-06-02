using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            ViewBag.DrectorCount = await _db.Employees.Include(x => x.Position).Where(x => x.Position.Id == 1).CountAsync();
            ViewBag.ManagerCount = await _db.Employees.Include(x => x.Position).Where(x => x.Position.Id == 2).CountAsync(); 
            return View();
        }

        //#region TotalSalary
        //public async Task<int> TotalSalaryAsync()
        //{
        //    int totalsalary = 0;
        //    List<Employee> employees = await _db.Employees.Where(x => !x.IsDeactive).Include(x => x.Position).ToListAsync();
        //    foreach (var item in employees)
        //    {
        //        totalsalary += item.Position.Salary;
        //    }
        //    return totalsalary;
        //}
        //#endregion


    }
}
