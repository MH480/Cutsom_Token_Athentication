using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ORM.InfraStructures
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TheDbContext>
    {
        public TheDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                // .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TheDbContext>();
            // var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=testDB;Trusted_connection=true;MultipleActiveResultSets=true");
            return new TheDbContext(builder.Options);
        }
    }
}