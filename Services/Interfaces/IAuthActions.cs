using Microsoft.AspNetCore.Identity;
using Models.Models;

namespace Services.Interfaces
{
    public interface IAuthActions<Entity>  where Entity : class
    {
        UserManager<AppUser> GetUserManager();
        SignInManager<AppUser> GetSigningManager();
        string GetSecurityKey();
        
    }
}