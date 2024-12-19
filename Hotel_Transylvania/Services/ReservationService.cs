using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Transylvania.Services
{
    public class ReservationService : IReservationService
    {

        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate, ApplicationDbContext dbContext)
        {
            var allRooms = dbContext
                .Rooms
                .ToList();

            var overlappingDates = dbContext
                .Reservations
                .Where(r => r.CheckinDate < checkoutDate && r.CheckoutDate > checkinDate)
                .ToList();

            var reservedRoomNumbers = overlappingDates
                .Select(r => r.RoomNumber)
                .Distinct()
                .ToList();

            var availableRooms = allRooms
                .Where(r => !reservedRoomNumbers
                .Contains(r.RoomNumber))
                .ToList();

            return availableRooms;
        }


        public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber, ApplicationDbContext dbContext)
        {
            if (!GetAvailableRooms(checkinDate, checkoutDate, dbContext)
                .Any(r => r.RoomNumber == roomNumber))
            {
                throw new Exception("Room is unavailable on the selected dates. Try again.");
                //Console.WriteLine("Room unavailable on selected dates. Try again.");
            }


            var guest = dbContext.Guests.FirstOrDefault(g => g.Id == guestId);
            var room = dbContext.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (guest == null || room == null)
            {
                throw new InvalidOperationException("Guest or Room not found.");
            }

            var reservation = new Reservation()
            {
                GuestID = guestId,
                RoomNumber = roomNumber,
                CheckinDate = checkinDate,
                CheckoutDate = checkoutDate,
                TimeOfReservation = DateTime.Now,
                IsReservationActive = true
            };


            guest.Reservations.Add(reservation);
            room.Reservations.Add(reservation);
            dbContext.Reservations.Add(reservation);

            dbContext.SaveChanges();
        }

        //public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber, ApplicationDbContext dbContext)
        //{
        //    if (!GetAvailableRooms(checkinDate, checkoutDate, dbContext)
        //        .Any(r => r.RoomNumber == roomNumber))
        //    {
        //        throw new Exception("Room is unavailable on the selected dates. Try again.");
        //        //Console.WriteLine("Room unavailable on selected dates. Try again.");
        //    }

        //    var reservation = new Reservation()
        //    {
        //        RoomNumber = roomNumber,
        //        CheckinDate = checkinDate,
        //        CheckoutDate = checkoutDate,
        //        TimeOfReservation = DateTime.Now,
        //        IsReservationActive = true
        //    };

        //    var guestToCheckin = dbContext.Guests
        //    .FirstOrDefault(g => g.Id == guestId);
        //    if (guestToCheckin == null)
        //    {
        //        throw new Exception("Guest not found.");
        //    }
        //    else
        //    {
        //        guestToCheckin.Reservations.Add(reservation);
        //    }
        //    dbContext.SaveChanges();
        //}

        public int CountReservations(ApplicationDbContext dbContext)
        {
            return dbContext.Reservations.Count();
        }

        //public void ShowReservations(ApplicationDbContext dbContext)
        //{
        //    Console.WriteLine($"Reservation\tRoom\tCheck-in Date\tCheck-Out Date\tGuest Id");

        //    var reservations = dbContext.Reservations;
        //    foreach ( var reservation in reservations)
        //    {
        //        Console.WriteLine(reservation);
        //    }

        //}

        public void ShowReservations(ApplicationDbContext dbContext)
        {
            Console.WriteLine($"Reservation\tRoom\tCheck-in Date\tCheck-Out Date\tGuest Id");

            var guestsWithReservation = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .Include(r => r.Guests)
                .ToList();

            guestsWithReservation
                .ForEach(r =>
                {
                    Console.WriteLine($"{r.Id}\t\t{r.RoomNumber}" +
                        $"\t{r.CheckinDate:yyyy-MM-dd}\t{r.CheckoutDate:yyyy-MM-dd}" +
                        $"\t{r.Id}");

                });
        }
        public void ShowReservation(ApplicationDbContext dbContext)
        {
            Console.WriteLine("I show reservations.");
        }

        public void UpdateReservation(Guest guest, ApplicationDbContext dbContext)
        {
            Console.WriteLine("I update reservations");
        }
        public void RemoveReservation(int reservationToRemove, ApplicationDbContext dbContext)
        {
            var guestsWithReservation = dbContext.Guests
                .Where(g => g.Reservations.Count > 0)
                .ToList();

            guestsWithReservation
                .ForEach(g =>
                {
                    g.Reservations
                    .Where(r => r.Id == reservationToRemove)
                    .ToList()
                    .ForEach(r =>
                    {
                        r.IsReservationActive = false;
                    });
                });
            dbContext.SaveChanges();
        }
    }
}