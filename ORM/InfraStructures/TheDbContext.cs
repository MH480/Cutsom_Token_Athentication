using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models.Models;
namespace ORM.InfraStructures
{
    public class TheDbContext : IdentityDbContext<User>
    {
        public TheDbContext(DbContextOptions<TheDbContext> options):base(options)
        {
            
        }

        public void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}