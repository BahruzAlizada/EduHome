using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewsModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username can be not null")]
        public string Username { get; set; }
       
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
