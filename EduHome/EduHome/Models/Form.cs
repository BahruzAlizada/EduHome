using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Form
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name can not be null")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email can not be null")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Subject can not be null")]
        public string Subject { get; set; }
        [Required(ErrorMessage ="Message can not be null")]
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool isDeactive { get; set; }
    }
}
