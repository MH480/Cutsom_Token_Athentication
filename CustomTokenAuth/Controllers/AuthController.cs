using Microsoft.AspNetCore.Mvc;
using Commen;
using ORM.InfraStructures;
using Models.Models;

namespace CustomTokenAuth.Controllers
{
    public class AuthController : BaseController<string>
    {
        public AuthController(TheDbContext context) : base(context)
        {
        }

        public IActionResult index()
        {
            return new ContentResult{Content = "in dastan ha hamishe has"};
        }

        public Token CreateToken()
        {
            return  repo.CreateToken();
        }
    }
}