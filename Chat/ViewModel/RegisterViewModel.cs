using System.ComponentModel.DataAnnotations;

namespace Chat.ViewModel
{
    public class RegisterViewModel: LoginViewModel
    {
        [Required(ErrorMessage = "Пароль не может быть пустым.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 50 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Email не может быть пустым.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ФИО не может быть пустое.")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
    }
}
