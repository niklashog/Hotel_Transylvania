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

        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate)
        {
            using (var dbContext = DataInitializer.GetDbContext())
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
        }

        public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                if (!GetAvailableRooms(checkinDate, checkoutDate)
                    .Any(r => r.RoomNumber == roomNumber))
                {
                    throw new Exception("Room is unavailable on the selected dates. Try again.");
                    //Console.WriteLine("Room unavailable on selected dates. Try again.");
                }

                var reservation = new Reservation()
                {
                    RoomNumber = roomNumber,
                    CheckinDate = checkinDate,
                    CheckoutDate = checkoutDate,
                    TimeOfReservation = DateTime.Now,
                    IsReservationActive = true
                };

                var guestToCheckin = dbContext.Guests
                .FirstOrDefault(g => g.GuestId == guestId);
                if (guestToCheckin == null)
                {
                    throw new Exception("Guest not found.");
                }
                else
                {
                    guestToCheckin.Reservations.Add(reservation);
                }
                dbContext.SaveChanges();
            }
        }

        public int CountReservations()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                return dbContext.Reservations.Count();
            }
        }
        public void ShowReservations()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                Console.WriteLine($"Reservation\tRoom\tCheck-in Date\tCheck-Out Date\tGuest Id");

                var guestsWithReservation = dbContext.Guests
                    .Where(g => g.Reservations.Count > 0)
                    .ToList();

                guestsWithReservation
                    .ForEach(g =>
                    {
                        g.Reservations
                        .Where(r => r.IsReservationActive)
                        .ToList()
                        .ForEach(r =>
                        {
                            Console.WriteLine($"{r.ReservationId}\t\t{r.RoomNumber}" +
                                $"\t{r.CheckinDate:yyyy-MM-dd}\t{r.CheckoutDate:yyyy-MM-dd}" +
                                $"\t{g.GuestId}");
                        });
                    });
            }
        }
        public void ShowReservation()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                
            }
            Console.WriteLine("I show reservations.");
        }

        public void UpdateReservation(Guest guest)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                
            }
            Console.WriteLine("I update reservations");
        }
        public void RemoveReservation(int reservationToRemove)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var guestsWithReservation = dbContext.Guests
                    .Where(g => g.Reservations.Count > 0)
                    .ToList();

                guestsWithReservation
                    .ForEach(g =>
                    {
                        g.Reservations
                        .Where(r => r.ReservationId == reservationToRemove)
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
}