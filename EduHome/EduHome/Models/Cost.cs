using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Cost
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="cost can not be null")]
        public int Costs { get; set; }
        [Required(ErrorMessage ="Cost Description can not be null")]
        public string CostDescription { get; set; }
        public string By { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
