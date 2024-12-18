using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Services
{
    public class GuestService : IGuestService
    {
        public void AddGuest(Guest guest)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                dbContext.Guests.Add(guest);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                return dbContext.Guests;
            }
        }
        public void DisplayActiveGuests(int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var activeGuests = dbContext.Guests
                .Where(g => g.IsGuestActive)
                .ToList();

                activeGuests
                    .ForEach(g =>
                    {
                        var reservation = g.Reservations.FirstOrDefault();

                        Console.SetCursorPosition(x, y++);
                        if (reservation != null)
                            Console.WriteLine($"* Guest ID: {g.GuestId}, Name: {g.FirstName} {g.Surname}");
                        else
                            Console.WriteLine($"Guest ID: {g.GuestId}, Name: {g.FirstName} {g.Surname}");
                    });

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("\n\n* Guest has active reservation");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void GetInctiveGuests(int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var inactiveGuests = dbContext.Guests
            .Where(g => g.IsGuestActive == false)
            .ToList();

                inactiveGuests
                .ForEach(g =>
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"Guest ID: {g.GuestId}, Name: {g.FirstName} {g.Surname}");
                });
            }
        }
        public void PrintGuestDetails(int guestId, int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var selectedGuest = dbContext.Guests
            .First(g => g.GuestId == guestId);
                var selectedGuestReservations = selectedGuest.Reservations.ToList();

                string activeOrInactive;
                if (selectedGuest.IsGuestActive)
                    activeOrInactive = "Active";
                else
                    activeOrInactive = "Inactive";

                Console.SetCursorPosition(x, y);
                Console.WriteLine($"Guest ID:\t\t{selectedGuest.GuestId}");
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine($"Status:\t\t{activeOrInactive}");
                Console.SetCursorPosition(x, y + 2);
                Console.WriteLine($"First Name:\t{selectedGuest.FirstName}");
                Console.SetCursorPosition(x, y + 3);
                Console.WriteLine($"Surname:\t\t{selectedGuest.Surname}");
                Console.SetCursorPosition(x, y + 4);
                Console.WriteLine($"E-mail:\t\t{selectedGuest.Email}");
                Console.SetCursorPosition(x, y + 5);
                Console.WriteLine($"Phone number:\t{selectedGuest.Phone}");
            }
        }
        public Guest GetGuestById(int guestId, int x, int y)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var selectedGuest = dbContext.Guests
            .First(g => g.GuestId == guestId);

                return selectedGuest;
            }
        }
        public int CountAllGuests()
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                return dbContext.Guests.Count();
            }
        }

        public void UpdateGuestDetails(int guestToEdit, string[] editedGuestDetails)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var guestToUpdate = dbContext.Guests
                .First(g => g.GuestId == guestToEdit);

                guestToUpdate.FirstName = editedGuestDetails[0];
                guestToUpdate.Surname = editedGuestDetails[1];
                guestToUpdate.Email = editedGuestDetails[2];
                guestToUpdate.Phone = editedGuestDetails[3];

                dbContext.SaveChanges();
            }
        }


        public void RemoveGuest(int guestToDelete)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                var guest = dbContext.Guests
                .First(g => g.GuestId == guestToDelete);

                if (guest == null)
                {
                    Console.WriteLine("No guest found with that ID.");
                }
                else
                {
                    if (guest.Reservations.Count < 1)
                    {
                        guest.IsGuestActive = false;
                        Console.WriteLine("Guest deleted. Press 'Enter' to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Active reservation found. Try again when");
                        Console.WriteLine("reservations have been removed. ");
                        Console.ReadKey();
                    }
                }
                dbContext.SaveChanges();
            }

        }
        public void ReActivateGuest(int guestToReactivate)
        {
            using (var dbContext = DataInitializer.GetDbContext())
            {
                dbContext.Guests
                .First(g => g.GuestId == guestToReactivate)
                .IsGuestActive = true;
                dbContext.SaveChanges();
            }
        }
    }
}