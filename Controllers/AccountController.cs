using Microsoft.AspNetCore.Mvc;
using register.ViewModels;

namespace register.Controllers;

public class AccountController : Controller
{
    [HttpGet("signup")]
    public IActionResult Signup() => View();

    [HttpPost("singup")]
    public IActionResult Signup(SignUpViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        return Ok("Вы успешно зарегестрироавны!");
    }
}