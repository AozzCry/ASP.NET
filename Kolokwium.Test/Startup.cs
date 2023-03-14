using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Kolokwium.Model;
using Kolokwium.Services.ConcreteServices;
using Kolokwium.Services.Configuration.AutoMapperProfiles;
using Kolokwium.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MainProfile));
            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb")
                );
            services.AddIdentity<User, Role>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoleManager<RoleManager<Role>>()
                .AddUserManager<UserManager<User>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient(typeof(ILogger), typeof(Logger<Startup>));
            services.AddTransient<IClientService, ClientService>();
            services.SeedData();
        }
    }
}
