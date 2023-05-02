using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> events = await _db.Events.Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).Take(4).ToListAsync();
            return View(events);
        }

      
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
