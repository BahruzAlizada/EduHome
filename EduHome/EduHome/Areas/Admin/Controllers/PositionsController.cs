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
    [Authorize(Roles ="Admin")]
    public class PositionsController : Controller
    {
        private readonly AppDbContext _db;

        public PositionsController(AppDbContext db)
        {
            _db=db;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Position> positions = await _db.Positions.ToListAsync();
            return View(positions);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Position position)
        {
            #region Exist
            bool isExsit = await _db.Positions.AnyAsync(x => x.PositionName == position.PositionName);
            if (isExsit)
            {
                ModelState.AddModelError("PositionName", "This Position already is exist");
                return View();
            }
            #endregion

            await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            Position dbposition = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbposition == null)
                return BadRequest();

            return View(dbposition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,Position position)
        {
            if (id == null)
                return NotFound();
            Position dbposition = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbposition == null)
                return BadRequest();

            #region Exist
            bool isExsit = await _db.Positions.AnyAsync(x => x.PositionName == position.PositionName && x.Id!=id);
            if (isExsit)
            {
                ModelState.AddModelError("PositionName", "This Position already is exist");
                return View();
            }
            #endregion

            dbposition.PositionName=position.PositionName;
            dbposition.Salary = position.Salary;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
                return NotFound();
            Position dbposition = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (dbposition == null)
                return BadRequest();

            if (dbposition.IsDeactive)
                dbposition.IsDeactive = false;
            else
                dbposition.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
