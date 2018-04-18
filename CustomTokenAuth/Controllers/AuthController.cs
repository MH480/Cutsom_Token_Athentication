using System;
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
using Services.Interfaces;
namespace CustomTokenAuth.Controllers
{

    [Route("api/[Controller]")]
    public class AuthController : BaseController<Token> , IAuthActions<Token>
    {
        private UserManager<AppUser> mUserManager;
        private SignInManager<AppUser> mSigninManager;
        private string Skey { get; set; }
        public AuthController(TheDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            string key
         ) : base(context)
        {
            this.mUserManager = userManager;
            this.mSigninManager = signInManager;
            this.Skey = key;
        }

        public IActionResult index()
        {
            return new ContentResult { Content = "in dastan ha hamishe has" };
        }
        [HttpPost("CreateToken")]
        public TServiceResult<Token> CreateToken([FromBody] UserVM user)
        {
            return repo.CreateToken(user,Skey);
        }

        [Authorize]
        public IActionResult TestPrivacy()
        {
            return new ContentResult{Content = $"hi this is Authorized {HttpContext.User.Identity.Name}"};
        }

        [HttpPost("SignUp")]
        public async Task<TServiceResult<Token>> SignUpAsync(UserVM data)
        {
            return await repo.SignUpAsync(data,this);
        }

        [HttpPost("Login")]
        public async Task<Token> LoginAsync(UserVM data, string returnUrl)
        {
            var res = await mSigninManager.PasswordSignInAsync(data.UserName, data.Password, true, false);
            if (res.Succeeded)
                return new Token(){Hash = "success",ExpireDate = DateTime.Now};
            return new Token();
        }

        public UserManager<AppUser> GetUserManager()
        {
            return mUserManager;
        }

        public SignInManager<AppUser> GetSigningManager()
        {
            return mSigninManager;
        }

        public string GetSecurityKey()
        {
            return Skey;
        }
    }
}