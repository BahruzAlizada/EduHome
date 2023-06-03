using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ProfitController : Controller
    {
        private readonly AppDbContext _db;

        public ProfitController(AppDbContext db)
        {
            _db = db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Profit> profits = await _db.Profits.ToListAsync();

            int totalProfit = 0;
            foreach (var item in profits)
            {
                totalProfit += item.Profitt;
            }
            ViewBag.TotalProfit = totalProfit;
            return View(profits);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Profit profit)
        {
            bool isExist = await _db.Profits.AnyAsync(x => x.Profitt <= 0);
            if (isExist)
            {
                ModelState.AddModelError("Profitt", "This is wrong");
                return View();
            }

			profit.By = User.Identity.Name;

			Cash cash = await _db.Cashs.FirstOrDefaultAsync();
            cash.Balance += profit.Profitt;
            cash.Description = profit.Description;
            cash.By = profit.By;
            cash.CreatedTime = profit.CreatedTime;
            cash.LastModifiedMoney = profit.Profitt;
            
            await _db.Profits.AddAsync(profit);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion   
    }
}
