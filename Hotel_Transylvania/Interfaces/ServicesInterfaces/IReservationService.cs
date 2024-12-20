using Hotel_Transylvania.Data;
using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ServicesInterfaces
{
    public interface IReservationService
    {
        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate, ApplicationDbContext dbContext);
        public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber, ApplicationDbContext dbContext);
        public int CountReservations(ApplicationDbContext dbContext);
        public void ShowReservations(ApplicationDbContext dbContext);
        public void ShowInactiveReservations(ApplicationDbContext dbContext);
        public void ShowReservationDetails(Reservation reservationToChange, ApplicationDbContext dbContext);
        public void UpdateReservation(Guest guest, ApplicationDbContext dbContext);
        public void RemoveReservation(int id, ApplicationDbContext dbContext);

    }
}