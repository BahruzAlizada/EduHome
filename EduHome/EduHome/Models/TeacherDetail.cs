using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class TeacherDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
        public string Experience { get; set; }
        public string Hobby { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
    }
}
