using System.ComponentModel.DataAnnotations;

namespace register.ViewModels;

public class SignInViewModel
{
    public string ReturnUrl { get; set; }

    [Required(ErrorMessage = "Введите ваш email адрес")]
    [EmailAddress(ErrorMessage = "Неправельный формат email адреса.")]
    [Display(Name = "Ваш email")]   
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите пароль")]
    [MinLength(6, ErrorMessage = "Пароль должен состоять не менее из 6 символов.")]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}