using System.Threading.Tasks;

namespace Mica.Application.Services.Abstract.Sender
{
    public interface ISmsSenderService
    {
        Task SendSmsAsync(string number, string message);
    }
}
