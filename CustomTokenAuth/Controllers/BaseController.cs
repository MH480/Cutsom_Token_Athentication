using Microsoft.AspNetCore.Mvc;

namespace CustomTokenAuth.Controllers
{
    public class BaseController<Entity> : Controller where Entity : class
    {
        
    }
}