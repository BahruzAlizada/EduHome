using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _db;

        public EventsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string search)
        {
            List<Event> events = new List<Event>();

            if (!string.IsNullOrEmpty(search))
            {
                events = await _db.Events.Where(x => x.Name.Contains(search)).ToListAsync();
                return View(events);
            }
            else
            {
                events = await _db.Events.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).ToListAsync();

                return View(events);
            }
             
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Event dbevent = await _db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (dbevent == null)
                return BadRequest();

            return View(dbevent);
        }
    }
}
