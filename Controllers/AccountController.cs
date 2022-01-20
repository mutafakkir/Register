using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using register.Entity;
using register.ViewModels;

namespace register.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userM;
    private readonly SignInManager<User> _signInM;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILogger<AccountController> logger)
    {
        _userM = userManager;
        _signInM = signInManager;
        _logger = logger;
    }

    [HttpGet("signup")]
    public IActionResult Signup(string returnUrl)
    {
        return View(new SignUpViewModel() { ReturnUrl = returnUrl ?? string.Empty });
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignUpViewModel model)
    {
        var user = new User()
        {
            Fullname = model.Fullname,
            Email = model.Email
        };

        var result = await _userM.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return LocalRedirect($"/account/signup?returnUrl={model.ReturnUrl}");
        }

        return BadRequest(JsonSerializer.Serialize(result.Errors));
    }

    [HttpGet("signin")]
    public IActionResult Signin(string returnUrl)
    {
        return View(new SignInViewModel() { ReturnUrl = returnUrl });
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin(SignInViewModel model)
    {
        var user = await _userM.FindByEmailAsync(model.Email);
        if (user != null)
        {
            await _signInM.PasswordSignInAsync(user, model.Password, false, false); // isPersistant

            return LocalRedirect($"{model.ReturnUrl ?? "/"}");
        }

        return BadRequest("Wrong credentials");
    }
}