using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string By { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeactive { get; set; }
    }
}
