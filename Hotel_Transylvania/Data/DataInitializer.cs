using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotel_Transylvania.Data
{
    public static class DataInitializer
    {

        public static void MigrateAndSeed()
        {
            using (var dbContext = GetDbContext())
            {
                var guest1 = new Guest
                {
                    FirstName = "Anna",
                    Surname = "Svensson",
                    Email = "anna.svensson@example.com",
                    Phone = "0701234567",
                    Reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        RoomNumber = 101,
                        GuestID = 1,
                        NumberOfAdditionalBeds = 0,
                        CheckinDate = DateTime.Now,
                        CheckoutDate = DateTime.Now.Date.AddDays(+2),
                        TimeOfReservation = DateTime.Now.Date.AddDays(-30),
                        IsReservationActive = true
                    },
                    new Reservation
                    {
                        RoomNumber = 101,
                        GuestID = 1,
                        NumberOfAdditionalBeds = 0,
                        CheckinDate = DateTime.Now.Date.AddDays(+21),
                        CheckoutDate = DateTime.Now.Date.AddDays(+23),
                        TimeOfReservation = DateTime.Now.Date.AddDays(-14),
                        IsReservationActive = true
                    }
                }
                };
                var guest2 = new Guest
                {
                    FirstName = "Henrik",
                    Surname = "Larsson",
                    Email = "henke.larssa@legend.com",
                    Phone = "0707654321"
                };
                var guest3 = new Guest
                {
                    FirstName = "Viktor",
                    Surname = "Gyökeres",
                    Email = "victor.y.gok@hotmail.com",
                    Phone = "0705554443"
                };
                var guest4 = new Guest
                {
                    FirstName = "Thomas",
                    Surname = "Brolin",
                    Email = "tompa.snurr@gest.nu",
                    Phone = "0701122333"
                };

                dbContext.Guests.Add(guest1);
                dbContext.Guests.Add(guest2);
                dbContext.Guests.Add(guest3);
                dbContext.Guests.Add(guest4);

                var room101 = new Room
                {
                    RoomNumber = 101,
                    RoomType = "Single",
                    RoomSize = 8,
                    AdditionalBeddingNumber = 0,
                };
                var room102 = new Room
                {
                    RoomNumber = 102,
                    RoomType = "Single",
                    RoomSize = 13,
                    AdditionalBeddingNumber = 1,
                };
                var room103 = new Room
                {
                    RoomNumber = 103,
                    RoomType = "Double",
                    RoomSize = 19,
                    AdditionalBeddingNumber = 1,
                };
                var room201 = new Room
                {
                    RoomNumber = 201,
                    RoomType = "Double",
                    RoomSize = 19,
                    AdditionalBeddingNumber = 1,
                };
                var room202 = new Room
                {
                    RoomNumber = 202,
                    RoomType = "Double",
                    RoomSize = 21,
                    AdditionalBeddingNumber = 2,
                };
                var room301 = new Room
                {
                    RoomNumber = 301,
                    RoomType = "Suite",
                    RoomSize = 32,
                    AdditionalBeddingNumber = 2,
                };

                dbContext.Rooms.Add(room101);
                dbContext.Rooms.Add(room102);
                dbContext.Rooms.Add(room103);
                dbContext.Rooms.Add(room201);
                dbContext.Rooms.Add(room202);
                dbContext.Rooms.Add(room301);

                dbContext.SaveChanges();
            }
        }

        public static ApplicationDbContext GetDbContext()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"AppSettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = config.GetConnectionString("DefaultConnection");

            options.UseSqlServer(connectionString);

            return new ApplicationDbContext(options.Options);
        }
    }
}
