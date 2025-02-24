using SocialMedia.Models;

namespace SocialMedia.Repositories;

public interface IAuthRepository
{
    Task<ApplicationUser> FindByEmailAsync(string email);
    Task<ApplicationUser> FindByIdAsync(string userId);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<bool> CreateUserAsync(ApplicationUser user, string password);
    Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    Task<bool> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
}