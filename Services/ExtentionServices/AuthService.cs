using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.ModelMappers;
using Models.Models;
using Models.ViewModels;
using Services.Interfaces;
using Services.ServiceResults;

namespace Services.ExtentionServices
{
    public static class AuthService
    {
        public static TServiceResult<Token> CreateToken(this IActions<Token> repo)
        {
            var token = new Token();
            repo.Insert(token);
            repo.SaveChanges();
            return new TServiceResult<Token>(token);
        }

        public static async Task<TServiceResult<Token>> SignUpAsync(this IActions<Token> repo, UserVM data,UserManager<AppUser> mUserManager)  
        {
            Token t = new Token();
            var u = data.MapProp<UserVM, AppUser>(new AppUser());
            var result = await mUserManager.CreateAsync(u, data.Password);
            if (result.Succeeded)
                t.Hash = "user is created";
            else
                t.Hash = string.Join("\n",result.Errors);
            return new TServiceResult<Token>(t,t.Hash,result.Succeeded);
        }

        public static async Task<TServiceResult<Token>> LoginAsync(this IActions<Token> repo, UserVM data,SignInManager<AppUser> mSigninManager)  
        {
            Token t = new Token();
            var user = data.MapProp<UserVM, AppUser>(new AppUser());
            var res = await mSigninManager.PasswordSignInAsync(user, data.Password, true, true);
            if (res.Succeeded)
                t.Hash = "user is created";
            
            return new TServiceResult<Token>(t,t.Hash,res.Succeeded);
        }


    }
}