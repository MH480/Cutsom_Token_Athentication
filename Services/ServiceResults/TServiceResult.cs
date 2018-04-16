using Services.Interfaces;

namespace Services.ServiceResults
{
    public class TServiceResult<TResult> : ITServiceResult<TResult> where TResult : class
    {
        public TServiceResult() : this(null,"",true)
        {
            
        }

        public TServiceResult(TResult data): this(data,"",true)
        {
            
        }

        public TServiceResult(TResult data,string msg):this(data,msg,true)
        {
            
        }

        public TServiceResult(TResult data,string msg,bool succeed)
        {
            ReturnValue = data;
            Message = msg;
            Successfull = succeed;
        }
        public TResult ReturnValue { get; set; }
        public string Message { get; set; }
        public bool Successfull { get; set; }
    }
}