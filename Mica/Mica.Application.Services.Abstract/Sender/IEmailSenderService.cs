using System.Threading.Tasks;

namespace Mica.Application.Services.Abstract.Sender
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
