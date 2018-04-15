using Microsoft.AspNetCore.Mvc;
using Commen;
using ORM.InfraStructures;
using Models.Models;
using Services.ExtentionServices;

namespace CustomTokenAuth.Controllers
{
    [Route("api/[Controller]")]
    public class AuthController : BaseController<Token>
    {
        public AuthController(TheDbContext context) : base(context)
        {
        }

        public IActionResult index()
        {
            return new ContentResult{Content = "in dastan ha hamishe has"};
        }
        [HttpPost("CreateToken")]
        public Token CreateToken()
        {
            return repo.CreateToken();
        }
    }
}