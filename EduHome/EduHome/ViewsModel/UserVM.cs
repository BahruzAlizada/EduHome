using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewsModel
{
    public class UserVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "FullName can not be null")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Username can be not null")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsDeactive { get; set; }
    }
}
