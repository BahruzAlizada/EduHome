using EduHome.DAL;
using EduHome.Helper;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbacksController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public FeedbacksController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env=env;
        }
        public async Task<IActionResult> Index()
        {
            List<Feedback> feedbacks = await _db.Feedbacks.ToListAsync();
            return View(feedbacks);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Feedback feedback)
        {
            if (feedback.FullName == null)
            {
                ModelState.AddModelError("FullName", "Full Name can not be null");
                return View();
            }

            if (feedback.Description==null)
            {
                ModelState.AddModelError("Description", "Description can not be null");
                return View();
            }

            #region Photo
            if (feedback.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }

            if (!feedback.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select image type");
                return View();
            }

            if (feedback.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "Max 256Kb");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "img", "testimonial");
            feedback.Image = await feedback.Photo.SaveFileAsync(folder);

            #endregion
            await _db.Feedbacks.AddAsync(feedback);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Feedback dbfeedback = await _db.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
            if(dbfeedback == null)
            {
                return BadRequest();
            }

            if (dbfeedback.IsDeactive)
            {
                dbfeedback.IsDeactive = false;
            }
            else
            {
                dbfeedback.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
