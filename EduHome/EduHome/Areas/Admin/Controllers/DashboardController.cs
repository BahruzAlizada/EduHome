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
		  
		#region Index
		public async Task<IActionResult> Index()
		{
			#region Profit
			List<Profit> profits = await _db.Profits.ToListAsync();
			int totalProfit = 0;
			foreach (var item in profits)
			{
				totalProfit += item.Profitt;
			}
			ViewBag.TotalProfit = totalProfit;
			#endregion

			#region Cost
			List<Cost> cost = await _db.Costs.ToListAsync();
			int totalCost = 0;
			foreach (var item in cost)
			{
				totalCost += item.Costs;
			}
			ViewBag.TotalCost = totalCost;
			#endregion

			#region Salary
			int totalsalary = 0;
			List<Employee> employees = await _db.Employees.Where(x => !x.IsDeactive).Include(x => x.Position).ToListAsync();
			foreach (var item in employees)
			{
				totalsalary += item.Position.Salary;
			}
			ViewBag.TotalSalary = totalsalary;
			#endregion

			#region Cash

			Cash cash = await _db.Cashs.FirstOrDefaultAsync();
			cash.Balance -= totalsalary;
			#endregion
			return View(cash);
		}
		#endregion
	}
}
