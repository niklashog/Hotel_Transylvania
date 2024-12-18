﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotel_Transylvania.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=BoolAndBreakfast;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
        public static ApplicationDbContext GetDbContext()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            return new ApplicationDbContext(options.Options);
        }
    }
}