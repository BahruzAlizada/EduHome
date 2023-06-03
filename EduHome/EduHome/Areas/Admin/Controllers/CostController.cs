using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

			Cash cash = await _db.Cashs.FirstOrDefaultAsync();
			cash.Balance -= cost.Costs;
			cash.Description = cost.CostDescription;
			cash.By = cost.By;
			cash.CreatedTime = cost.CreatedTime;
			cash.LastModifiedMoney = cost.Costs;

			await _db.Costs.AddAsync(cost);
              await _db.SaveChangesAsync();
              return RedirectToAction("Index");
            
        }
        #endregion   
    }
}
