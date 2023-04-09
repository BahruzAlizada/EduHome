using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class TeacherViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public TeacherViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Teacher> teachers = new List<Teacher>();
            if (take == 0)
            {
                teachers = await _db.Teachers.Where(x=>!x.IsDeactive).ToListAsync();
            }
            else
            {
                teachers = await _db.Teachers.Where(x=>!x.IsDeactive).Take(4).ToListAsync();
            }
                   
            return View(teachers);
        }
    }
}
