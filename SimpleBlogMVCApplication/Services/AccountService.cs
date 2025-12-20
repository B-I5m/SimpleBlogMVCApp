using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SimpleBlogMVCApplication.Dtos;
using SimpleBlogMVCApplication.Models.Entities;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Response<LoginDto>> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);
        if (user is null)
            return new Response<LoginDto>(HttpStatusCode.BadRequest, "Пользователь не найден");

        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);
        if (!result.Succeeded)
            return new Response<LoginDto>(HttpStatusCode.BadRequest, "Неверный пароль");

        return new Response<LoginDto>(loginDto);
    }

    public async Task<Response<RegisterDto>> RegisterAsync(RegisterDto model)
    {
        var user = new User
        {
            UserName = model.Username,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return new Response<RegisterDto>(HttpStatusCode.BadRequest, result.Errors.Select(e => e.Description).ToList());

        return new Response<RegisterDto>(model);
    }
}