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
    public class CostController : Controller
    {
        private readonly AppDbContext _db;

        public CostController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Cost> cost = await _db.Costs.ToListAsync();
            int totalCost = 0;
            foreach (var item in cost)
            {
                totalCost += item.Costs;
            }
            List<Employee> employees = await _db.Employees.Where(x => !x.IsDeactive).Include(x => x.Position).ToListAsync();
            foreach (var item in employees)
            {
                totalCost += item.Position.Salary;
            }
            ViewBag.TotalCost = totalCost;
            return View(cost);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Cost cost)
        {
            bool isExist = await _db.Costs.AnyAsync(x => x.Costs <= 0);
            if (isExist)
            {
                ModelState.AddModelError("Costs", "This is wrong");
                return View();
            }
              cost.By=User.Identity.Name;
              await _db.Costs.AddAsync(cost);
              await _db.SaveChangesAsync();
              return RedirectToAction("Index");
            
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Cost dbcost = await _db.Costs.FindAsync(id);
            if (dbcost == null)
                return BadRequest();   

            return View(dbcost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Cost cost)
        {
            if (id == null)
                return NotFound();
            Cost dbcost = await _db.Costs.FindAsync(id);
            if (dbcost == null)
                return BadRequest();

            bool isExist = await _db.Costs.AnyAsync(x => x.Costs <= 0);
            if (isExist)
            {
                ModelState.AddModelError("Costs", "This is wrong");
                return View();
            }
            cost.By= User.Identity.Name;
            dbcost.Costs = cost.Costs;
            dbcost.CostDescription = cost.CostDescription;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
