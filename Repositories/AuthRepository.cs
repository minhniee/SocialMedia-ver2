using Microsoft.AspNetCore.Identity;
using SocialMedia.Models;

namespace SocialMedia.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<ApplicationUser> _user;

    public AuthRepository(UserManager<ApplicationUser> user)
    {
        _user = user;
    }
    public async Task<ApplicationUser> FindByEmailAsync(string email)
    {
        return await _user.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser> FindByIdAsync(string userId)
    {
        return await _user.FindByIdAsync(userId);
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _user.CheckPasswordAsync(user, password);
    }

    public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
    {
        var result = await _user.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
    {
        return await _user.GeneratePasswordResetTokenAsync(user);
    }

    public async Task<bool> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
    {
        var result = await _user.ResetPasswordAsync(user, token, newPassword);
        return result.Succeeded;
    }
}