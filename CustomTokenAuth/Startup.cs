using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
using Microsoft.IdentityModel.Tokens;
using Models.Identities;
using Models.Models;
using ORM.InfraStructures;
using Services.AuthSenderManager;
using Services.Interfaces;

[assembly: ConnectionStringAttr(ApplicationDatabase.DbTest)]
[assembly: SignInSecurityKeyAttr("khjags hkahu g7^*^YATSDgau16b dKW DG^TASWD^&Y")]
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
            // if (env.IsDevelopment())
            //     builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = Assembly.GetEntryAssembly();
            string conStr = assemblies.GetCustomAttribute<ConnectionStringAttr>().ConnectionString;
            string Skey = assemblies.GetCustomAttribute<SignInSecurityKeyAttr>().SecurityKey;
            services.AddMvc();

            services.AddDbContext<TheDbContext>(context =>
            {
                context.UseSqlServer(conStr);
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                
            });

            
            services.AddAuthentication()
                .AddJwtBearer(option =>{
                    option.TokenValidationParameters = new TokenValidationParameters(){
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "localhost",
                        ValidAudience = "localhost",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Skey))
                    };
                });

            services.ConfigureApplicationCookie(options =>{
                options.LoginPath = "/Auth/Login";
            });
            services.AddTransient<ISmsSender,AuthSender>();
            services.AddTransient<IEmailSender,AuthSender>();
            services.AddTransient<string>(opt => Skey);
            services.AddIdentity<AppUser, UserRole>((config)=>
            {
                config.SignIn.RequireConfirmedPhoneNumber = true;
                
                
            })
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
