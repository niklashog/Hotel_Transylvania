﻿using Hotel_Transylvania.Interfaces.ModelsInterfaces;
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
        public List<IReservation> Reservations { get; set; }
        public List<IRoom> Rooms { get; set; }
        //public IGuest Guest { get; set; }
        //public IRoom Room { get; set; }
        //public IReservation Reservation { get; set; }
    }
}
