using Hotel_Transylvania.Data;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IGuestService
    {
        public void AddGuest(IGuest guest);
        public ApplicationDbContext_FAKE GetGuestDbContext();
        public IEnumerable<IGuest> GetAllGuests();
        public void GetActiveGuests(int x, int y);
        public void GetInctiveGuests(int x, int y);
        public IGuest GetGuestById(int guestId, int x, int y);
        public void PrintGuestDetails(int guestId, int x, int y);
        public int CountAllGuests();

        public void ReActivateGuest(int guestToReactivate);
        public void UpdateGuestDetails(int guestIdInput, string[] updatedGuestDetails);
        public void RemoveGuest(int guestToDelete);
    }
}
