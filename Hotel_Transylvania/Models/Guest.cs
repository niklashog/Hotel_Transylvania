﻿using Hotel_Transylvania.Interfaces.ModelsInterfaces;

namespace Hotel_Transylvania.Models
{
    public class Guest : IGuest
    {
        public int GuestID { get; set; }
        public int? ReservationID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ReservationHistory { get; set; }
        public bool IsGuestActive { get; set; } = true;
        public List<Reservation>? Reservations { get; set; } = new List<Reservation>();

        //public List<IReservation> GuestReservations { get; set; } = new List<IReservation>();

    }
}
