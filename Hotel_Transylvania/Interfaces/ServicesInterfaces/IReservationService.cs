using Hotel_Transylvania.Interfaces.ModelsInterfaces;
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
        public IEnumerable<IRoom> GetAvailableRooms(DateTime checkinDate, DateTime checkoutDate);
        public void AddReservation(int guestId, DateTime checkinDate, DateTime checkoutDate, int roomNumber);
        public int CountReservations();
        public void ShowReservations();
        public void ShowReservation(IGuest guest);
        public void UpdateReservation(IGuest guest);
        public void RemoveReservation(IGuest guest);

    }
}