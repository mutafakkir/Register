using System.ComponentModel.DataAnnotations;

namespace register.ViewModels;

public class SignUpViewModel : IValidatableObject
{
    public string ReturnUrl { get; set; }
    
    [Required(ErrorMessage = "Введите Имя и Фамилию")]
    [Display(Name = "Имя Фамилия")]
    public string Fullname { get; set; }

    [Required(ErrorMessage = "Введите дату рождения")]
    [Display(Name = "Дата рождения")]
    public DateTimeOffset Birthdate { get; set; }
    
    [Required(ErrorMessage = "Введите номер телефона")]
    [RegularExpression(@"^[\+]?(998[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{3}[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{2}[-\s\.]?)$",
    ErrorMessage = "Формат телефон номера неправельный.")]
    [Display(Name = "Телефон номер")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Введите ваш email адрес")]
    [EmailAddress(ErrorMessage = "Неправельный формат email адреса.")]
    [Display(Name = "Ваш email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Введите пароль")]
    [MinLength(6, ErrorMessage = "Пароль должен состоять не менее из 6 символов.")]
    [Display(Name = "Пароль")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Подтвердите пароль")]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают, проверьте еще раз.")]
    [Display(Name = "Подтвердить пароль")]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "Запомнить")]
    public bool RememberMe { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var now = DateTimeOffset.Now;
        var limit = new DateTime(now.Year - 13, now.Month, now.Day);
        Console.WriteLine($"{limit} {Birthdate}");

        if(Birthdate > limit)
        {
            yield return new ValidationResult($"Вы должны быть старше 13 лет!", new [] { nameof(Birthdate)});
        }
    }
}