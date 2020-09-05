using Application.DTO.Email;
using Application.Interface;
using Domain.Helpers;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService: IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        /// <summary>
        ///  This method is especifically responsible to send email
        /// </summary>
        /// <param name="_recipient">E-mails list to send to</param>
        /// <param name="_subject">Subject of e-mail</param>
        /// <param name="_content">HTML Template</param>
        /// <returns></returns>
        public async Task Send(List<EmailRecipientDTO> _recipient, string _subject, string _content)
        {
            var apiKey = Environment.GetEnvironmentVariable(_emailSettings.Key);
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_emailSettings.DomainEmail, _emailSettings.DomainName),
                Subject = _subject,
                HtmlContent = _content
            };

            foreach(var item in _recipient)
                message.AddTo(new EmailAddress(item.Email, item.Name));

            await client.SendEmailAsync(message).ConfigureAwait(false);
        }
    }
}
