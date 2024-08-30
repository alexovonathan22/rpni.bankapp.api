using RpnInnovation.Application.Features.Email;
using MimeKit;
using MailKit.Net.Smtp;
using RpnInnovation.Domain.Entities;
using MailKit.Security;
using Microsoft.Extensions.Options;
using RpnInnovation.Domain.AppSettings;
using Microsoft.VisualBasic.FileIO;

namespace RpnInnovation.Infrastructure.Integrations.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailOption)
        {
            _emailSettings = emailOption.Value; 
        }
        public bool SendEmailAsync(EmailResponse email)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("RpniBank", _emailSettings.Sender));
                message.To.Add(new MailboxAddress($"{email.Customer.FirstName}", email.To));
                message.Subject = email.Subject;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Content };

                using var client = new SmtpClient();
                client.Connect(_emailSettings.SmptServer, _emailSettings.SmptPort, SecureSocketOptions.StartTls);

                client.Authenticate(_emailSettings.Sender, _emailSettings.Password);
                // to make a non-async entity(method, obj) async use task obj
                
                    client.Send(message);
               
               
                client.Disconnect(true);
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public Task<bool> SendEmailWithAttachmentAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
