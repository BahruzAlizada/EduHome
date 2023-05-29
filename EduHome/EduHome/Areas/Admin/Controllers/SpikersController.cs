using EduHome.DAL;
using EduHome.Helper;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SpikersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public SpikersController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Spiker> spiker = await _db.Spikers.ToListAsync();
            return View(spiker);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Spiker spiker)
        {
            #region Photo
            if (spiker.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }
            if (!spiker.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Select image type");
                return View();
            }
            if (spiker.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "Max 256Kb");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "img", "spiker");
            spiker.Image = await spiker.Photo.SaveFileAsync(folder);
            #endregion

            await _db.Spikers.AddAsync(spiker);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Spiker dbspiker = await _db.Spikers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbspiker == null)
                return BadRequest();

            return View(dbspiker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Spiker spiker)
        {
            if (id == null)
                return NotFound();
            Spiker dbspiker = await _db.Spikers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbspiker == null)
                return BadRequest();

            #region Photo
            if(spiker.Photo != null)
            {
                if (!spiker.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Select image type");
                    return View();    
                }
                if (spiker.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256Kb");
                    return View();
                }
                string folder = Path.Combine(_env.WebRootPath, "img", "spiker");
                spiker.Image = await spiker.Photo.SaveFileAsync(folder);
                string path = Path.Combine(_env.WebRootPath, folder, dbspiker.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbspiker.Image = spiker.Image;

            }
            #endregion

            dbspiker.FullName = spiker.FullName;
            dbspiker.Role = spiker.Role;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Spiker dbspiker = await _db.Spikers.FirstOrDefaultAsync(x=>x.Id==id);
            if (dbspiker == null)
                return BadRequest();

            if (dbspiker.IsDeactive)
                dbspiker.IsDeactive = false;
            else
                dbspiker.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
