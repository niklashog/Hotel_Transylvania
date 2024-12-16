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
        public void AddReservation(int guestId, Reservation reservation);
    }
}