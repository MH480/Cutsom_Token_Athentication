using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ORM.InfraStructures;

namespace CustomTokenAuth.DataManagers
{
    public class AppUserManager : UserManager<TheDbContext>
    {
        public AppUserManager(IUserStore<TheDbContext> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TheDbContext> passwordHasher, IEnumerable<IUserValidator<TheDbContext>> userValidators, IEnumerable<IPasswordValidator<TheDbContext>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TheDbContext>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}