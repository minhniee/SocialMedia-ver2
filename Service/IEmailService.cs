namespace SocialMedia.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendPasswordResetEmailAsync(string email, string token);
        Task SendWelcomeEmailAsync(string email, string userName);
    }




}