using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class NoticesViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public NoticesViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Notice> notice = await _db.Notices.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(5).ToListAsync();

            return View(notice);
        }
    }
}
