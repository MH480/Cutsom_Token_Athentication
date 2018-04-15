using Microsoft.AspNetCore.Mvc;
using ORM.InfraStructures;
using Services.ExtentionServices;
using Services.Interfaces;

namespace CustomTokenAuth.Controllers
{
    public class BaseController<Entity> : Controller where Entity : class
    {
        protected readonly IActions<Entity> repo;
        public BaseController(TheDbContext context)
        {
            repo = new BaseService<Entity>(context);
        }
    }
}