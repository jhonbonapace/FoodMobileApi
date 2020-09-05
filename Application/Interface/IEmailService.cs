using Application.DTO.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEmailService
    {
        Task Send(List<EmailRecipientDTO> _recipient, string _subject, string _content);
    }
}
