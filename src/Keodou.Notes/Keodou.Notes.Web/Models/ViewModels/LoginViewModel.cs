using System.ComponentModel.DataAnnotations;

namespace Keodou.Notes.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым, введите логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым, введите пароль")]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }
    }
}
