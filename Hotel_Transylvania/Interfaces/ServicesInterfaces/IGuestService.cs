﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IGuestService
    {
        public void AddGuest(Guest guest, ApplicationDbContext dbContext);
        public IEnumerable<Guest> GetAllGuests(ApplicationDbContext dbContext);
        public void DisplayActiveGuests(ApplicationDbContext dbContext);
        public void DisplayInactiveGuests(ApplicationDbContext dbContext);
        public void DisplayGuestDetails(int guestId, ApplicationDbContext dbContext);
        public Guest GetGuestById(int guestId, ApplicationDbContext dbContext);
        public List<Guest> ListOfActiveGuests(ApplicationDbContext dbContext);
        public List<Guest> ListOfInctiveGuests(ApplicationDbContext dbContext);
        public void ReActivateGuest(string guestToReactivate, ApplicationDbContext dbContext);
        public void UpdateGuestDetails(int guestIdInput, string[] updatedGuestDetails, ApplicationDbContext dbContext);
        public void RemoveGuest(string guestIdToDelete, ApplicationDbContext dbContext);
    }
}
