using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeactive { get; set; }
    }
}
