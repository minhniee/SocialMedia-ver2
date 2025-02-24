using SocialMedia.Service;
using SocialMedia.Services;

namespace SocialMedia.Test;


class Program
{
    private readonly IEmailService _emailService;

    public Program(IEmailService emailService)
    {
        _emailService = emailService;
    }

    static async Task Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IEmailService, EmailService>() // Đăng ký EmailService
            .BuildServiceProvider();

        var emailService = serviceProvider.GetRequiredService<IEmailService>();

        // Gửi email
        await emailService.SendEmailAsync("metoo2k3@gmail.com", "Test Email", "This is a test email");

        Console.WriteLine("Email đã được gửi!");
    }
}