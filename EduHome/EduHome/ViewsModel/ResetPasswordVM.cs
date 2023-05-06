using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewsModel
{
    public class ResetPasswordVM
    {
        public string id { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
    }
}
