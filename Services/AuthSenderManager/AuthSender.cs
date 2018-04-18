using System.Threading.Tasks;
using ORM.InfraStructures;
using Services.Interfaces;
using Services.ServiceResults;

namespace Services.AuthSenderManager    
{
    public class AuthSender : ISmsSender, IEmailSender
    {
        private TheDbContext context;
        public AuthSender(TheDbContext context)
        {
            this.context = context;
        }

        public Task<ServiceResult> SendEmailAsync(string email, string subject, string message)
        {
            

            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> SendMessageByCallAsync(string number, string template, int message1, int message2 = 0, int message3 = 0, bool readState = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> SendSmsAsync(string number, string template, string message1, string message2 = null, string message3 = null, bool readState = false)
        {
            throw new System.NotImplementedException();
        }
    }
}