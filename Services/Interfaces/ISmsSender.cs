using System.Threading.Tasks;
using Services.ServiceResults;

namespace Services.Interfaces
{
    public interface ISmsSender
    {
        Task<ServiceResult> SendSmsAsync(string number, string template, string message1, string message2 = null,
            string message3 = null, bool readState = false);

        Task<ServiceResult> SendMessageByCallAsync(string number, string template, int message1, int message2 = 0,
            int message3 = 0, bool readState = false);
    }
}