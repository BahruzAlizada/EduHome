using EduHome.DAL;
using EduHome.Helper;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public EventsController(AppDbContext db,IWebHostEnvironment env)
        {
            _env = env;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> events = await _db.Events.Include(x=>x.EventDetail).Include(x=>x.EventSpikers).ThenInclude(x=>x.Spiker).ToListAsync();
            return View(events);
        }

       public IActionResult Create()
       {
            return View();
       }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Event events)
        {
            #region Photo
            if (events.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }

            if (!events.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select image type");
                return View();
            }

            if (events.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "max 256Kb");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "img", "event");
            events.Image = await events.Photo.SaveFileAsync(folder);
            #endregion

           
            await _db.Events.AddAsync(events);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Event dbevent = await _db.Events.Include(x=>x.EventDetail).Include(x=>x.EventSpikers).ThenInclude(x=>x.Spiker).FirstOrDefaultAsync(x => x.Id == id);
            if (dbevent == null)
                return BadRequest();

            return View(dbevent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Event events)
        {
            if (id == null)
                return NotFound();
            Event dbevent = await _db.Events.Include(x => x.EventDetail).Include(x => x.EventSpikers).ThenInclude(x => x.Spiker).FirstOrDefaultAsync(x => x.Id == id);
            if (dbevent == null)
                return BadRequest();

            #region Photo
            if (events.Photo != null)
            {
                if (!events.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Just Select image type");
                    return View();
                }

                if (events.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256Kb");
                    return View();
                }

                string folder = Path.Combine(_env.WebRootPath, "img", "event");
                events.Image = await events.Photo.SaveFileAsync(folder);
                string path = Path.Combine(_env.WebRootPath, folder, dbevent.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbevent.Image = events.Image;
            }
            #endregion

            dbevent.Name = events.Name;
            dbevent.Location = events.Location;
            dbevent.CreatedTime = events.CreatedTime;
            dbevent.StartTime = events.StartTime;
            dbevent.EndTime=events.EndTime;
            dbevent.EventDetail.Description = events.EventDetail.Description;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
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

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Event dbevent = await _db.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (dbevent == null)
                return BadRequest();

            if (dbevent.IsDeactive)
                dbevent.IsDeactive = false;
            else
                dbevent.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    
    }
}
