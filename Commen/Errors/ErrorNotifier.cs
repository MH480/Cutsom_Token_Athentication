namespace Commen.Errors
{
    public class ErrorNotifier
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public string Id { get; set; }

        public ErrorNotifier() : this("")
        {}

        public ErrorNotifier(string msg) : this(msg,ErrorTypeEnum.Noun)
        {
            
        }

        public ErrorNotifier(string msg,ErrorTypeEnum type) 
        {
            this.Msg = msg;
            switch (type)
            {
                case ErrorTypeEnum.NotFound:
                    Code = 402;
                break;
                case ErrorTypeEnum.Failur:
                    Code = 401;
                break;
                case ErrorTypeEnum.NotMatch:
                    Code = 400;
                break;
                default:
                    Code = 404;
                break;
            }
        }
    }


    public enum ErrorTypeEnum
    {
        NotFound,NotMatch,NotAuthurize,Failur,Noun
    }

    
}