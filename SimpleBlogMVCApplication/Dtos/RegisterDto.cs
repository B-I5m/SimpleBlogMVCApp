using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVCApplication.Dtos;

public class RegisterDto
{
    [Required] public string FirstName { get; set; } = null!;
    [Required] public string LastName { get; set; } = null!;
    [Required] public string Username { get; set; } = null!;
    [Required] public string Email { get; set; } = null!;
    [Required] public string PhoneNumber { get; set; } = null!;
    [Required, DataType(DataType.Password)] public string Password { get; set; } = null!;
    [Required, Compare("Password")] public string ConfirmPassword { get; set; } = null!;
}