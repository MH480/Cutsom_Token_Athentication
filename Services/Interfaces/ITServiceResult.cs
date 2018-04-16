namespace Services.Interfaces
{
    internal interface ITServiceResult<TResult> : IServiceResult where TResult : class
    {
        TResult ReturnValue { get; set; }
    }
}