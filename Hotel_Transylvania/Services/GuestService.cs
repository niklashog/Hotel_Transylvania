using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Services
{
    public class GuestService : IGuestService
    {
        private readonly ApplicationDbContext_FAKE _dbContext;

        public GuestService(ApplicationDbContext_FAKE dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddGuest(IGuest guest)
        {
            _dbContext.Guests.Add(guest);
        }
        public ApplicationDbContext_FAKE GetGuestDbContext()
        {
            return _dbContext;
        }

        public IEnumerable<IGuest> GetAllGuests()
        {
            return _dbContext.Guests;
        }
        public void DisplayActiveGuests(int x, int y)
        {
            var activeGuests = _dbContext.Guests
                .Where(g => g.IsGuestActive)
                .ToList();

            activeGuests
                .ForEach(g =>
                {
                    var reservation = g.Reservations.FirstOrDefault();

                    Console.SetCursorPosition(x, y++);
                    if (reservation != null)
                        Console.WriteLine($"* Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
                    else
                        Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
                });

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("\n\n* Guest has active reservation");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GetInctiveGuests(int x, int y)
        {
            var inactiveGuests = _dbContext.Guests
            .Where(g => g.IsGuestActive == false)
            .ToList();

            inactiveGuests
            .ForEach(g =>
            {
                Console.SetCursorPosition(x, y++);
                Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
            });
        }
        public void PrintGuestDetails(int guestId, int x, int y)
        {
            var selectedGuest = _dbContext.Guests
            .First(g => g.GuestID == guestId);
            var selectedGuestReservations = selectedGuest.Reservations.ToList();

            string activeOrInactive;
            if (selectedGuest.IsGuestActive)
                activeOrInactive = "Active";
            else
                activeOrInactive = "Inactive";

            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Guest ID:\t\t{selectedGuest.GuestID}");
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
        public IGuest GetGuestById(int guestId, int x, int y)
        {
            var selectedGuest = _dbContext.Guests
            .First(g => g.GuestID == guestId);

            return selectedGuest;
        }
        public int CountAllGuests()
        {
            return _dbContext.Guests.Count();
        }

        public void UpdateGuestDetails(int guestToEdit, string[] editedGuestDetails)
        {
            var guestToUpdate = _dbContext.Guests
                .Find(g => g.GuestID == guestToEdit);

            guestToUpdate.FirstName = editedGuestDetails[0];
            guestToUpdate.Surname = editedGuestDetails[1];
            guestToUpdate.Email = editedGuestDetails[2];
            guestToUpdate.Phone = editedGuestDetails[3];
        }


        public void RemoveGuest(int guestToDelete)
        {
            var guest = _dbContext.Guests
                .Find(g => g.GuestID == guestToDelete);

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

        }
        public void ReActivateGuest(int guestToReactivate)
        {
            _dbContext.Guests
                .First(g => g.GuestID == guestToReactivate)
                .IsGuestActive = true;
        }
    }
}