using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
