using System.Threading.Tasks;
using Services.ServiceResults;

namespace Services.Interfaces
{
    public interface IEmailSender
    {
        Task<ServiceResult> SendEmailAsync(string email, string subject, string message);
    }
}