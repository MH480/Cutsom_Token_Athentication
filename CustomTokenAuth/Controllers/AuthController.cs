using Microsoft.AspNetCore.Mvc;
using Commen;
using ORM.InfraStructures;
using Models.Models;
using Services.ExtentionServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Models.ViewModels;
using Models.ModelMappers;
using System.Collections.Generic;
using Services.ServiceResults;

namespace CustomTokenAuth.Controllers
{

    [Route("api/[Controller]")]
    public class AuthController : BaseController<Token>
    {
        private UserManager<AppUser> mUserManager;
        private SignInManager<AppUser> mSigninManager;
        public AuthController(TheDbContext context
        , UserManager<AppUser> userManager,
         SignInManager<AppUser> signInManager) : base(context)
        {
            this.mUserManager = userManager;
            this.mSigninManager = signInManager;
        }

        public IActionResult index()
        {
            return new ContentResult { Content = "in dastan ha hamishe has" };
        }
        [HttpPost("CreateToken")]
        public TServiceResult<Token> CreateToken()
        {
            return repo.CreateToken();
        }

        [Authorize]
        public IActionResult TestPrivacy()
        {
            return new ContentResult{Content = $"hi this is Authorized {HttpContext.User.Identity.Name}"};
        }

        [HttpPost("SignUp")]
        public async Task<TServiceResult<Token>> SignUpAsync(UserVM data)
        {
            return await repo.SignUpAsync(data,mUserManager);
        }

        [HttpPost("Login")]
        public async Task<Token> LoginAsync(UserVM data, string returnUrl)
        {
            var user = data.MapProp<UserVM, AppUser>(new AppUser());
            var res = await mSigninManager.PasswordSignInAsync(user, data.Password, true, false);
            if (res.Succeeded)
                return new Token(){Hash = "success"};
            return new Token();
        }
    }
}