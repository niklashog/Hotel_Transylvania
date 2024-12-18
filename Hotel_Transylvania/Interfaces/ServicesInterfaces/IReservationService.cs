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
        public IEnumerable<Room> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate);
        public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber);
        public int CountReservations();
        public void ShowReservations();
        public void ShowReservation();
        public void UpdateReservation(Guest guest);
        public void RemoveReservation(int id);

    }
}