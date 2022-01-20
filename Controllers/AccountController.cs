using Microsoft.AspNetCore.Mvc;
using register.ViewModels;

namespace register.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Signup() => View();

    public IActionResult Sigup(SingUpViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        return Ok("Вы успешно зарегистрированы");
    }
}