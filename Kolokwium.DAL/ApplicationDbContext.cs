﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Kolokwium.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        // table properties
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<CheckIn> CheckIns { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //configuration commands            
            optionsBuilder.UseLazyLoadingProxies(); //enable lazy loading proxies
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
            modelBuilder.Entity<User>()
             .ToTable("AspNetUsers")
             .HasDiscriminator<int>("UserType")
             .HasValue<User>((int)RoleValue.User)
             .HasValue<CareTaker>((int)RoleValue.CareTaker)
             .HasValue<Client>((int)RoleValue.Client);

            modelBuilder.Entity<RoomCheckIn>()
            .HasKey(sg => new { sg.RoomId, sg.CheckInId });

            modelBuilder.Entity<CheckIn>().HasOne(x => x.Client).WithMany(x=>x.CheckIns).OnDelete(DeleteBehavior.Restrict);

        }
    }
}