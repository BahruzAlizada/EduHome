using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Name can not be null")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname can not be null")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number can not be null")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Brith can not be null")]
        public DateTime Brith { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public bool IsMan { get; set; }
        public bool IsDeactive { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }

    }

   
}
