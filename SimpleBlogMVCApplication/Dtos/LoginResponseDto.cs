using System.Security.Claims;
using SimpleBlogMVCApplication.Models.Entities;

namespace _002.AuthenticationWithMvc.Dtos;

public class LoginResponseDto
{
    public User User { get; set; }
    public List<Claim> Claims { get; set; }
}