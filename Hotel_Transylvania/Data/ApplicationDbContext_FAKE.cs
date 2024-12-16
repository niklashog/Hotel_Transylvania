using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;

namespace Hotel_Transylvania.Data
{
    public class ApplicationDbContext_FAKE : IApplicationDbContext_FAKE
    {
        public List<IGuest> Guests { get; set; } = new List<IGuest>();
        public List<IReservation> Reservations { get; set; } = new List<IReservation>();
        public List<IRoom> Rooms { get; set; } = new List<IRoom>();
        //public IGuest Guest { get; set; }
        //public IRoom Room { get; set; }
        //public IReservation Reservation { get; set; }
    }
}