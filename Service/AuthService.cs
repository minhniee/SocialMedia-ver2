using Microsoft.AspNetCore.Identity;
using SocialMedia.Models;
using SocialMedia.Repositories;
using SocialMedia.Services;
using SocialMedia.ViewModels;

namespace SocialMedia.Service;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailService _emailService;

    public AuthService(IAuthRepository authRepository, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
    {
        _authRepository = authRepository;
        _signInManager = signInManager;
        _emailService = emailService;
    }

    public async Task<ServiceResponse<string>> LoginAsync(LoginViewModel model)
    {
        var user = await _authRepository.FindByEmailAsync(model.Email);
        if (user == null) return ServiceResponse<string>.ErrorResponse("User not found");
        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

        if (result.Succeeded) return ServiceResponse<string>.SuccessResponse(user.Id, "Login successful");

        return ServiceResponse<string>.ErrorResponse("Login failed");

    }

    public async Task<ServiceResponse<string>> RegisterAsync(RegisterViewModel model)
    {
        var userExists = await _authRepository.FindByEmailAsync(model.Email);
        if (userExists != null) return ServiceResponse<string>.ErrorResponse("User already exists");

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FullName = model.FullName,
            CreatedAt = DateTime.UtcNow,
            Avatar = "avatar",
            Bio = "bio",
            DateOfBirth = DateTime.Today,


        };

        var result = await _authRepository.CreateUserAsync(user, model.Password);

        if (result)
        {
            await _emailService.SendWelcomeEmailAsync(user.Email, user.FullName);
            return ServiceResponse<string>.SuccessResponse(user.Id, "User created successfully");
        }
        return ServiceResponse<string>.ErrorResponse("User creation failed");

    }

    public async Task<ServiceResponse<string>> ForgotPasswordAsync(ForgotPasswordViewModel model)
    {
        var user = await _authRepository.FindByEmailAsync(model.Email);
        if (user == null) return ServiceResponse<string>.ErrorResponse("User not found");

        var token = await _authRepository.GeneratePasswordResetTokenAsync(user);
        await _emailService.SendPasswordResetEmailAsync(user.Email, token);
        return ServiceResponse<string>.SuccessResponse(user.Id, "Password reset link sent to your email");
    }

    public async Task<ServiceResponse<bool>> ResetPasswordAsync(ResetPasswordViewModel model)
    {
        var user = await _authRepository.FindByEmailAsync(model.Email);

        if (user == null) return ServiceResponse<bool>.ErrorResponse("User not found");

        var result = await _authRepository.ResetPasswordAsync(user, model.Token, model.Password);
        if (result) return ServiceResponse<bool>.SuccessResponse(true, "Password reset successful");

        return ServiceResponse<bool>.ErrorResponse("Password reset failed");
    }

    public async Task<ServiceResponse<bool>> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return ServiceResponse<bool>.SuccessResponse(true, "Logout successful");
    }
}