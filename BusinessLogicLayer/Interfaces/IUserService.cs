using BusinessLogicLayer.Dtos.Auth;
using BusinessLogicLayer.Extended;

namespace BusinessLogicLayer.Interfaces;
public interface IUserService
{
    Task<AuthResult> RegisterAsync(RegisterUserDto dto);
    Task<AuthResult> LoginAsync(LoginUserDto dto);
}