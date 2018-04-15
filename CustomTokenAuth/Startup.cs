using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CustomTokenAuth.ApplicationEnum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models.Identities;
using Models.Models;
using ORM.InfraStructures;

[assembly: ConnectionStringAttr(ApplicationDatabase.DbTest)]
namespace CustomTokenAuth
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddEnvironmentVariables()
                    .AddJsonFile("appsetting.json", true, true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json");
            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = Assembly.GetEntryAssembly();
            string conStr = assemblies.GetCustomAttribute<ConnectionStringAttr>().ConnectionString;
            services.AddMvc();

            services.AddDbContext<TheDbContext>(context =>
            {
                context.UseSqlServer(conStr);
            });
            services.AddIdentity<User, UserRole>()
            .AddEntityFrameworkStores<TheDbContext>()
            .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routers =>
            {
                routers.MapRoute("default", "{controller}/{actions}/{id?}");

            });
        }
    }
}
