using System.ComponentModel.DataAnnotations;

namespace Chat.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Логин не может быть пустой.")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустой!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 50 символов")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
