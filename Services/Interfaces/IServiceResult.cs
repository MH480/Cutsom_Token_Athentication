namespace Services.Interfaces
{
    internal interface IServiceResult
    {
        string Message { get; set; } 
        bool Successfull { get; set; }
    } 
}