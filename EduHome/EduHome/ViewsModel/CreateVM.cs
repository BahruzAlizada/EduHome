using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewsModel
{
    public class CreateVM
    {
        [Required(ErrorMessage ="FullName can not be null")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Username can be not null")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Email can not be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password can not be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
       
    }
}
