using SocialMedia.ViewModels;

namespace SocialMedia.Service;

public interface IAuthService
{
    Task<ServiceResponse<string>> LoginAsync(LoginViewModel model);
    Task<ServiceResponse<string>> RegisterAsync(RegisterViewModel model);
    Task<ServiceResponse<string>> ForgotPasswordAsync(ForgotPasswordViewModel model);
    Task<ServiceResponse<bool>> ResetPasswordAsync(ResetPasswordViewModel model);
    Task<ServiceResponse<bool>> LogoutAsync();
}