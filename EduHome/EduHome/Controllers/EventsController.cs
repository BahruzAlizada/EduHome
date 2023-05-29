using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        #region Index
        public async Task<IActionResult> Index( int page = 1)
        {
            decimal take = 6;
            ViewBag.PageCount = Math.Ceiling((decimal)(await _db.Events.Where(x=>!x.IsDeactive).CountAsync()/take));

            List<Event> events = await _db.Events.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Skip((page-1)*6).Take((int)take).ToListAsync();
                return View(events);
         

        }
        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Event dbevent = await _db.Events.Include(x => x.EventDetail).Include(x => x.EventSpikers).ThenInclude(x => x.Spiker).FirstOrDefaultAsync(x => x.Id == id);
            if (dbevent == null)
                return BadRequest();

            return View(dbevent);
        }
        #endregion
    }
}
