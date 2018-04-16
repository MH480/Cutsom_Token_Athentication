using Services.Interfaces;

namespace Services.ServiceResults
{
    public class ServiceResult : IServiceResult
    {

        public ServiceResult() : this("", true)
        {

        }

        public ServiceResult(string msg) : this(msg, true)
        {

        }

        public ServiceResult(string msg, bool succeed)
        {
            Message = msg;
            Successfull = succeed;
        }

        public string Message { get; set; }
        public bool Successfull { get; set; }
    }
}