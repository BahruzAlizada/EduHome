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
    public class EmployesController : Controller
    {
        private readonly AppDbContext _db;

        public EmployesController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _db.Employees.Include(x => x.Position).ToListAsync();   
            return View(employees);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Positions = await _db.Positions.Where(x => !x.IsDeactive).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Employee employee,int positionId)
        {
            ViewBag.Positions = await _db.Positions.Where(x => !x.IsDeactive).ToListAsync();
            employee.PositionId = positionId;

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
