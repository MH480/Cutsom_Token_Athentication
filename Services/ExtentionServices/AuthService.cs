using Models.Models;
using Services.Interfaces;

namespace Services.ExtentionServices
{
    public static class AuthService
    {
        public static Token CreateToken(this IActions<Token> repo)
        {
            var token = new Token();
            repo.Insert(token);
            repo.SaveChanges();
            return token;
        }
    }
}