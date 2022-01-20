using Microsoft.AspNetCore.Mvc;
using register.ViewModels;

namespace register.Controllers;

public class AccountController : Controller
{
    [HttpGet("action")]
    public IActionResult Signup() => View();

    [HttpPost("action")]
    public IActionResult Signup(SignUpViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        return Ok("Вы успешно зарегестрироавны!");
    }
}