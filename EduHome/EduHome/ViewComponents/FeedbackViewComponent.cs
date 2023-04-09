using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class FeedbackViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public FeedbackViewComponent(AppDbContext db)
        {
            _db= db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Feedback> feedbacks = new List<Feedback>();

            feedbacks = await _db.Feedbacks.Where(x=>!x.IsDeactive).OrderByDescending(x => x.Id).Take(take).ToListAsync();
            return View(feedbacks);
        }

    }
}
