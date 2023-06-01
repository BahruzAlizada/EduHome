using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Position Name can not be null")]
        public string PositionName { get; set; }
        [Required(ErrorMessage = "Salary can not be null")]
        public int Salary { get; set; }
        public List<Employee> Employee { get; set; }
        public bool IsDeactive { get; set; }

    }
}
