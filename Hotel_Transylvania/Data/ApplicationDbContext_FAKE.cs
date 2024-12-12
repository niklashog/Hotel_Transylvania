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
        public List<IGuest> Guests { get; set; } = [];
        public List<IReservation> Reservations { get; set; } = [];
        public List<IRoom> Rooms { get; set; } = [];
    }
}