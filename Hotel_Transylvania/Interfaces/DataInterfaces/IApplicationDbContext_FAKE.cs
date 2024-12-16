using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.FakeDatabase
{
    public interface IApplicationDbContext_FAKE
    {
        public List<IGuest> Guests { get; set; }
        public List<IReservation> ReservationsOld { get; set; }
        public List<IRoom> Rooms { get; set; }
                //public Guest Guests { get; set; }
        //public Reservation Reservations { get; set; }
        //public Room Rooms { get; set; }
    }
}
