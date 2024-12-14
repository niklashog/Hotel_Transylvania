using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Data
{
    public class DataInitializer(
        ApplicationDbContext_FAKE applicationDbContext): IDataInitializer
    {
        private ApplicationDbContext_FAKE _dbContext;

        public ApplicationDbContext_FAKE SeedData()
        {
            _dbContext = applicationDbContext;

            SeedGuests();
            SeedRooms();
            SeedReservations();

            return _dbContext;
        }

        private ApplicationDbContext_FAKE SeedGuests()
        {
            var guest1 = new Guest
            {
                GuestID = 1,
                FirstName = "Anna",
                Surname = "Svensson",
                Email = "anna.svensson@example.com",
                Phone = "0701234567"
            };
            var guest2 = new Guest
            {
                GuestID = 2,
                FirstName = "Kanneth",
                Surname = "Andersson",
                Email = "kenneth.andersson@legend.com",
                Phone = "0707654321"
            };
            var guest3 = new Guest
            {
                GuestID = 3,
                FirstName = "Viktor",
                Surname = "Gyökeres",
                Email = "vigge.gook@hotmail.com",
                Phone = "0705554443"
            };
            var guest4 = new Guest
            {
                GuestID = 4,
                FirstName = "Thomas",
                Surname = "Brolin",
                Email = "tompa.snurr@restaurant.com",
                Phone = "0701122333"
            };


            _dbContext.Guests.Add(guest1);
            _dbContext.Guests.Add(guest2);
            _dbContext.Guests.Add(guest3);
            _dbContext.Guests.Add(guest4);

            return _dbContext;
        }


        private ApplicationDbContext_FAKE SeedRooms()
        {
            var room101 = new Room
            {
                RoomID = 101,
                RoomType = "Single",
                RoomSize = 8,
                AdditionalBeddingNumber = 0,
            };
            var room102 = new Room
            {
                RoomID = 102,
                RoomType = "Single",
                RoomSize = 13,
                AdditionalBeddingNumber = 1,
            };
            var room103 = new Room
            {
                RoomID = 103,
                RoomType = "Double",
                RoomSize = 19,
                AdditionalBeddingNumber = 1,
            };
            var room201 = new Room
            {
                RoomID = 201,
                RoomType = "Double",
                RoomSize = 19,
                AdditionalBeddingNumber = 1,
            };
            var room202 = new Room
            {
                RoomID = 202,
                RoomType = "Double",
                RoomSize = 21,
                AdditionalBeddingNumber = 2,
            };
            var room301 = new Room
            {
                RoomID = 301,
                RoomType = "KingSize",
                RoomSize = 32,
                AdditionalBeddingNumber = 2,
            };

            _dbContext.Rooms.Add(room101);
            _dbContext.Rooms.Add(room102);
            _dbContext.Rooms.Add(room103);
            _dbContext.Rooms.Add(room201);
            _dbContext.Rooms.Add(room202);
            _dbContext.Rooms.Add(room301);

            return _dbContext;
        }

        private ApplicationDbContext_FAKE SeedReservations()
        {
            var reservation1 = new Reservation
            {
                ReservationID = 1,
                RoomID = 301,
                GuestID = 1,
                NumberOfAdditionalBeds = 0,
                CheckinDate = DateTime.Today.Date,
                CheckoutDate = DateTime.Now.Date.AddDays(+2),
                TimeOfReservation = DateTime.Now.Date.AddDays(-30),
                IsReservationActive = true
            };
            _dbContext.Reservations.Add(reservation1);

            return _dbContext;
        }
    }
}
