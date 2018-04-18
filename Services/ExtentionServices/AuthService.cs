using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.ModelMappers;
using Models.Models;
using Models.ViewModels;
using Services.Interfaces;
using Services.ServiceResults;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Services.ExtentionServices
{
    public static class AuthService
    {
        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="data">should contains  UserID , FirstName , LastName
        /// </param>
        /// <returns></returns>
        public static TServiceResult<Token> CreateToken(this IActions<Token> repo,UserVM u,string key)
        {
            var t = new Token();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,u.Id),
                new Claim(JwtRegisteredClaimNames.GivenName,u.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,u.LastName)
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256Signature);

            var secToken = new JwtSecurityToken(
                issuer:"localhost",
                audience:"localhost",
                claims:claims,
                signingCredentials:credentials,
                notBefore:null,
                expires:DateTime.Now.AddDays(5));
            t.Hash = new JwtSecurityTokenHandler().WriteToken(secToken);
            t.ExpireDate = secToken.ValidTo;
            repo.Insert(t);
            repo.SaveChanges();
            return new TServiceResult<Token>(t);
        }

        
        public static async Task<TServiceResult<Token>> SignUpAsync(this IActions<Token> repo, UserVM data,IAuthActions<Token> dataManager)  
        {
            var u = data.MapProp<UserVM, AppUser>(new AppUser());
            var result = await dataManager.GetUserManager().CreateAsync(u, data.Password);
            if (result.Succeeded)
                return CreateToken(repo,data,dataManager.GetSecurityKey());
            return new TServiceResult<Token>(null,"",false);
        }

        public static async Task<TServiceResult<Token>> LoginAsync(this IActions<Token> repo, UserVM data,IAuthActions<Token> dataManager)  
        {
            Token t = new Token();
            var user = data.MapProp<UserVM, AppUser>(new AppUser());
            var res = await dataManager.GetSigningManager().PasswordSignInAsync(user.UserName, data.Password, true, true);
            if (!res.Succeeded)
                return new TServiceResult<Token>(null,"not found",false);
            user = await dataManager.GetUserManager().FindByNameAsync(user.UserName);
            
            if (! await dataManager.GetUserManager().IsInRoleAsync(user,"User"))
            {
                /*
                add memeber to roll
                 */
            }
            return CreateToken(repo,data,dataManager.GetSecurityKey());
        }

        

    }
}