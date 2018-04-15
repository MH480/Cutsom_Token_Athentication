using Microsoft.EntityFrameworkCore;

namespace ORM.InfraStructures
{
    public class TheDbContext : IdentityDbContext<User>
    {
        public TheDbContext(DbContextOptions<TheDbContext> options):base(options)
        {
            
        }
    }
}