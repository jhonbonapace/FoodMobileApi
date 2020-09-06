using Application.Interface;
using Domain.Helpers;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }


        /// <summary>
        ///  This method is especifically responsible to send email
        /// </summary>
        /// <param name="email">E-mail to send to</param>
        /// <param name="_subject">Subject of e-mail</param>
        /// <param name="_content">HTML Template</param>
        /// <returns></returns>
        private async Task Execute(string _subject, string _content, string email)
        {
            var apiKey = Environment.GetEnvironmentVariable(_emailSettings.Key);
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_emailSettings.DomainEmail, _emailSettings.DomainName),
                Subject = _subject,
                HtmlContent = _content
            };

            message.AddTo(new EmailAddress(email));

            await client.SendEmailAsync(message).ConfigureAwait(false);
        }
    }
}
