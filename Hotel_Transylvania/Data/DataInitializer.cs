using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Transylvania.Data
{
    public static class DataInitializer
    {

        public static void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();


            if (!dbContext.Rooms.Any(r => r.RoomNumber == 101))
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 101,
                    RoomType = "Single",
                    RoomSize = 8,
                    AdditionalBeddingNumber = 0,
                });

            if (!dbContext.Rooms.Any(r => r.RoomNumber == 102))
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 102,
                    RoomType = "Single",
                    RoomSize = 13,
                    AdditionalBeddingNumber = 0,
                });

            if (!dbContext.Rooms.Any(r => r.RoomNumber == 103))
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 103,
                    RoomType = "Double",
                    RoomSize = 19,
                    AdditionalBeddingNumber = 1,
                });

            if (!dbContext.Rooms.Any(r => r.RoomNumber == 201))
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 201,
                    RoomType = "Double",
                    RoomSize = 19,
                    AdditionalBeddingNumber = 1,
                });

            if (!dbContext.Rooms.Any(r => r.RoomNumber == 202))
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 202,
                    RoomType = "Double",
                    RoomSize = 21,
                    AdditionalBeddingNumber = 2,
                });

            if (!dbContext.Rooms.Any(r => r.RoomNumber == 301))
                dbContext.Rooms.Add(new Room
                {
                    RoomNumber = 301,
                    RoomType = "Suite",
                    RoomSize = 32,
                    AdditionalBeddingNumber = 2,
                });

            if (!dbContext.Guests.Any(g => g.Id == 1))
                dbContext.Guests.Add(new Guest
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
                            NumberOfAdditionalBeds = 0,
                            CheckinDate = DateTime.Now,
                            CheckoutDate = DateTime.Now.Date.AddDays(+2),
                            TimeOfReservation = DateTime.Now.Date.AddDays(-30),
                            IsReservationActive = true
                        },
                        new Reservation
                        {
                            RoomNumber = 101,
                            NumberOfAdditionalBeds = 0,
                            CheckinDate = DateTime.Now.Date.AddDays(+21),
                            CheckoutDate = DateTime.Now.Date.AddDays(+23),
                            TimeOfReservation = DateTime.Now.Date.AddDays(-14),
                            IsReservationActive = true
                        },
                        new Reservation
                        {
                            RoomNumber = 103,
                            NumberOfAdditionalBeds = 0,
                            CheckinDate = DateTime.Now.Date.AddDays(-2),
                            CheckoutDate = DateTime.Today.Date,
                            TimeOfReservation = DateTime.Now.Date.AddDays(-14),
                            IsReservationActive = false
                        }
                    }
                });


            if (!dbContext.Guests.Any(g => g.Id == 2))
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Henrik",
                    Surname = "Larsson",
                    Email = "henke.larssa@legend.com",
                    Phone = "0707654321"
                });
            if (!dbContext.Guests.Any(g => g.Id == 3))
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Viktor",
                    Surname = "Gyökeres",
                    Email = "victor.gyokeres@guldbollen24.se",
                    Phone = "0705554443"
                });
            if (!dbContext.Guests.Any(g => g.Id == 4))
                dbContext.Guests.Add(new Guest
                {
                    FirstName = "Claus",
                    Surname = "Saint",
                    Email = "santa@budbee.io",
                    Phone = "+46701940010",
                    Reservations = new List<Reservation>
                    {
                        new Reservation
                        {
                            RoomNumber = 301,
                            NumberOfAdditionalBeds = 2,
                            CheckinDate = new DateTime(2025, 12, 24),
                            CheckoutDate = new DateTime(2025, 12, 26),
                            TimeOfReservation = new DateTime(2024, 12, 24),
                            IsReservationActive = true
                        },
                    }
                });
            dbContext.SaveChanges();
        }
    }
}
