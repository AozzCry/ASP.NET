using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.DAL;
using Kolokwium.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Kolokwium.Test
{
    public static class Extensions
    {
        // Create sample data
        public static async void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            // add seed data here

            var careTakerRole = new Role()
            {
                Id = 2,
                Name = "CareTaker",
                RoleValue = RoleValue.CareTaker
            };
            await roleManager.CreateAsync(careTakerRole);
            var clienttRole = new Role()
            {
                Id = 1,
                Name = "Client",
                RoleValue = RoleValue.Client
            };
            await roleManager.CreateAsync(clienttRole);
            var adminRole = new Role()
            {
                Id = 3,
                Name = "Admin",
                RoleValue = RoleValue.Admin
            };
            await roleManager.CreateAsync(adminRole);

            var c1 = new Client()
            {
                Id = 1,
                FirstName = "Jacek",
                LastName = "Kowalczyk",
                UserName = "a1@eg.eg",
                Email = "a1@eg.eg",
            };
            dbContext.Users.Add(c1);

            var c2 = new Client()
            {
                Id = 2,
                FirstName = "asd",
                LastName = "Kowalfsdczyk",
                UserName = "a1@eg.eg",
                Email = "a1@eg.eg",
            };
            dbContext.Users.Add(c2);

            var c3 = new Client()
            {
                Id = 3,
                FirstName = "aasdvsd",
                LastName = "asd",
                UserName = "a1@eg.eg",
                Email = "a1@eg.eg",
            };
            dbContext.Users.Add(c3);

            var i1 = new CheckIn()
            {
                Id = 1,
                Cost = 19.99,
                Data = DateTime.Now
            };
            await dbContext.AddAsync(i1);

            await dbContext.SaveChangesAsync();
        }
    }
}
