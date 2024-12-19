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
            var allRooms = dbContext.Rooms
                .ToList();

            var unavailableRooms = dbContext.Reservations
                .Where(r => r.CheckinDate < checkoutDate && r.CheckoutDate > checkinDate && r.IsReservationActive)
                .ToList();

            var reservedRoomNumbers = unavailableRooms
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
            }
            else
            {
                var guest = dbContext.Guests.FirstOrDefault(g => g.Id == guestId);
                var room = dbContext.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                if (guest == null || room == null)
                {
                    throw new InvalidOperationException("Guest or Room not found.");
                }
                else
                {
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
            }
        }

        public int CountReservations(ApplicationDbContext dbContext)
        {
            return dbContext.Reservations.Count();
        }

        public void ShowReservations(ApplicationDbContext dbContext)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Primary Guest\t\tRoom\tCheck-in\tCheck-Out\tReservation Number");
            Console.ForegroundColor = ConsoleColor.White;

            var guestReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .Include(r => r.Guests)
                .ToList();

            foreach (var reservation in guestReservations)
            {
                foreach(var guest in reservation.Guests)
                {
                    Console.WriteLine($"{guest.Id} {guest.FirstName}{guest.Surname}" +
                    $"\t\t{reservation.RoomNumber}\t{reservation.CheckinDate:yyyy-MM-dd}" +
                    $"\t{reservation.CheckoutDate:yyyy-MM-dd}\t{reservation.Id}");
                }
            }
        }
        public void ShowInactiveReservations(ApplicationDbContext dbContext)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Primary Guest\t\tRoom\tCheck-in\tCheck-Out\tReservation Number");
            Console.ForegroundColor = ConsoleColor.White;

            var guestReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive == false)
                .Include(r => r.Guests)
                .ToList();

            foreach (var reservation in guestReservations)
            {
                foreach (var guest in reservation.Guests)
                {
                    Console.WriteLine($"{guest.Id} {guest.FirstName}{guest.Surname}" +
                    $"\t\t{reservation.RoomNumber}\t{reservation.CheckinDate:yyyy-MM-dd}" +
                    $"\t{reservation.CheckoutDate:yyyy-MM-dd}\t{reservation.Id}");
                }
            }
        }

        public void ShowReservationDetails(ApplicationDbContext dbContext)
        {
            Console.WriteLine("I show details of one reservation.");
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