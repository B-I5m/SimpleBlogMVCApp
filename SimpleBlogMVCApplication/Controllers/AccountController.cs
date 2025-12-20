using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCApplication.Dtos;
using SimpleBlogMVCApplication.Services;

public class AccountController : Controller
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginDto { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid) return View(model);

        var response = await _service.LoginAsync(model);
        if (response.StatusCode == 200)
            return RedirectToAction("Index", "Post");

        ModelState.AddModelError(string.Empty, string.Join("\n", response.Errors));
        return View(model);
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (!ModelState.IsValid) return View(model);

        var response = await _service.RegisterAsync(model);
        if (response.StatusCode == 200)
            return RedirectToAction("Login");

        ModelState.AddModelError(string.Empty, string.Join("\n", response.Errors));
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult AccessDenied() => View();
}