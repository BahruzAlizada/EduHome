using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EduHome.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set; }
        public bool IsDeactive { get; set; }
    }
}
