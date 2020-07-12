using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(
            IOptions<AuthMessageSenderOptions>
                optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions
            Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email,
            string subject, string message)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("pocketMenu");
            return Execute(apiKey, subject, message, email);
            //return Execute(Options.SendGridKey, subject, message, email);

        }

        public Task Execute(string apiKey, string subject,
            string message, string email)
        {
            apiKey = System.Environment.GetEnvironmentVariable("pocketMenu");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                //Options.SendGridUser

            From = new EmailAddress("kowerules@gmail.com",
                "pocketMenu"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
         //   msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}