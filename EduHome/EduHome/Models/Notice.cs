using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Notice
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Description can not be null")]
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeactive { get; set; }
    }
}
