using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PilatesStudio.Services;

public class SendGridEmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public SendGridEmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var apiKey = _configuration["SendGrid:ApiKey"];
        var fromEmail = _configuration["SendGrid:FromEmail"];
        var fromName = _configuration["SendGrid:FromName"];

        var client = new SendGridClient(apiKey);

        var from = new EmailAddress(fromEmail, fromName);
        var to = new EmailAddress(email);

        var msg = MailHelper.CreateSingleEmail(
            from,
            to,
            subject,
            plainTextContent: null,
            htmlContent: htmlMessage
        );

        await client.SendEmailAsync(msg);
    }
}
