using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Profit
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Profit can not be null")]
        public int Profitt { get; set; }
        [Required(ErrorMessage = "Profit Descreption can not be null")]
        public string Description { get; set; }
        public string By { get; set; }
        public DateTime CreatedTime { get; set; }=DateTime.UtcNow.AddHours(4);
    }
}
