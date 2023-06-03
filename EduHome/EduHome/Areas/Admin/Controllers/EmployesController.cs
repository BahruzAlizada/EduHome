using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Positions = await _db.Positions.Where(x => !x.IsDeactive).ToListAsync();

            if (id == null)
                return NotFound();
            Employee dbemp = await _db.Employees.Include(x => x.Position).FirstOrDefaultAsync(x => x.Id == id);
            if (dbemp == null)
                return BadRequest();

            return View(dbemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Employee emp,int positionId)
        {
            ViewBag.Positions = await _db.Positions.Where(x => !x.IsDeactive).ToListAsync();

            if (id == null)
                return NotFound();
            Employee dbemp = await _db.Employees.Include(x => x.Position).FirstOrDefaultAsync(x => x.Id == id);
            if (dbemp == null)
                return BadRequest();

            dbemp.PositionId = positionId;
            dbemp.Name = emp.Name;
            dbemp.Surname = emp.Surname;
            dbemp.Email = emp.Email;
            dbemp.PhoneNumber = emp.PhoneNumber;
            dbemp.IsMan = emp.IsMan;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Employee dbemp = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (dbemp == null)
                return BadRequest();

            if (dbemp.IsDeactive)
                dbemp.IsDeactive = false;
            else
                dbemp.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
