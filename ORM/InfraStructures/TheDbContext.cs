using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models.Models;
namespace ORM.InfraStructures
{
    public class TheDbContext : IdentityDbContext<AppUser>
    {
        public TheDbContext()
        {
            Database.EnsureCreated();
        }

        public TheDbContext(DbContextOptions<TheDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}