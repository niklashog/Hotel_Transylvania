using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
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
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"Guest ID: {g.GuestID}, Name: {g.FirstName} {g.Surname}");
                });
        }
        public void DisplayInctiveGuests(int x, int y)
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
        public void DisplaySingleActiveGuest(int guestId, int x, int y)
        {
            var selectedGuest = _dbContext.Guests
            .First(g => g.IsGuestActive == true && g.GuestID == guestId);
            
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Guest ID:\t\t#{selectedGuest.GuestID}");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine($"First Name:\t{selectedGuest.FirstName}");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine($"Surname:\t\t{selectedGuest.Surname}");
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine($"E-mail:\t\t{selectedGuest.Email}");
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine($"Phone number:\t{selectedGuest.Phone}");
        }
        public int CountAllGuests()
        {
            return _dbContext.Guests.Count();
        }

        public void UpdateGuestDetails(int guestIdInput, string[] updatedGuestDetails)
        {
            var guestToUpdate = _dbContext.Guests
                .Find(g => g.GuestID == guestIdInput);

            guestToUpdate.FirstName = updatedGuestDetails[0];
            guestToUpdate.Surname = updatedGuestDetails[1];
            guestToUpdate.Email = updatedGuestDetails[2];
            guestToUpdate.Phone = updatedGuestDetails[3];
        }


        public void RemoveGuest(int guestToDelete)
        {
            var guest = _dbContext.Guests
                .Find(g => g.GuestID == guestToDelete);

            if (guest != null)
            {
                guest.IsGuestActive = false;
            }
            else
            {
                Console.WriteLine("No guest found with that ID.");
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