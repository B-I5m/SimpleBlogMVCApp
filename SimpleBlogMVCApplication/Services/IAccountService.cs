using _002.AuthenticationWithMvc.Dtos;
using SimpleBlogMVCApplication.Dtos;

public interface IAccountService
{
    Task<Response<LoginDto>> LoginAsync(LoginDto loginDto);
    Task<Response<RegisterDto>> RegisterAsync(RegisterDto registerDto);
}