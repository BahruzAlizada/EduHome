using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _db;

        public ServicesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _db.Services.ToListAsync();
            return View(services);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Service service)
        {
            bool isExist=await _db.Services.AnyAsync(x=>x.Name==service.Name);

            if (isExist)
            {
                ModelState.AddModelError("Name", "This Service already is exist !");
                return View();
            }
           
            await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");  
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Service dbservice = await _db.Services.FirstOrDefaultAsync(x=>x.Id==id);

            if (dbservice == null)
            {
                return BadRequest();
            }
            
            return View(dbservice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Service service)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service dbservice = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (dbservice == null)
            {
                return BadRequest();
            }

            bool isExist = await _db.Services.AnyAsync(x => x.Name == service.Name && x.Id!=id );

            if (isExist)
            {
                ModelState.AddModelError("Name", "This Service already is exist !");
                return View();
            }

            dbservice.Name=service.Name;
            dbservice.Description=service.Description;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbservice = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if(dbservice== null)
            {
                return BadRequest();
            }
            return View(dbservice);
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbservice = await _db.Services.FirstOrDefaultAsync(x=>x.Id == id);
            if (dbservice == null)
            {
                return BadRequest();
            }

            if (dbservice.IsDeactive)
            {
                dbservice.IsDeactive = false;
            }
            else
            {
                dbservice.IsDeactive=true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        

    }
}
