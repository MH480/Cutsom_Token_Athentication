using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ORM.InfraStructures;

namespace CustomTokenAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

    //           using (var scope = host.Services.CreateScope())
    // {
    //     // Retrieve your DbContext isntance here
    //     var dbContext = scope.ServiceProvider.GetService<TheDbContext>();
 
    //     // place your DB seeding code here
        
    //     Seed(dbContext);
    // }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}
