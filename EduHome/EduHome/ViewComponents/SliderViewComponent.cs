using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public SliderViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        { 
            List <Slider> sliders = await _db.Sliders.Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).Take(take).ToListAsync();
            return View(sliders);
        }

    }
}
