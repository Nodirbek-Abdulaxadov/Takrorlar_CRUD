using AutoMapper;
using BusinessLogicLayer.Dtos.Auth;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services;
public class UserService(UserManager<User> userManager,
                         IMapper mapper)
    : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IMapper _mapper = mapper;

    public async Task<AuthResult> LoginAsync(LoginUserDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            return new AuthResult(false, new List<string> { "User not found" });
        }

        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!result)
        {
            return new AuthResult(false, new List<string> { "Wrong password" });
        }

        return new AuthResult(true, null);
    }

    public async Task<AuthResult> RegisterAsync(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;
        await _userManager.SetUserNameAsync(user, dto.Email);
        
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            return new AuthResult(false, result.Errors.Select(e => e.Description));
        }

        return new AuthResult(true, null);
    }
}
