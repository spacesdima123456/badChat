using System.ComponentModel.DataAnnotations;

namespace Chat.ViewModel
{
    public class RegisterViewModel: LoginViewModel
    {
        [Required(ErrorMessage = "Подтвердите пароль.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 50 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Email не может быть пустым.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
