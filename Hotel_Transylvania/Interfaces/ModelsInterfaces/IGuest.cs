using Hotel_Transylvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ModelsInterfaces
{
    public interface IGuest
    {
        public int GuestID { get; set; }
        public int? ReservationID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ReservationHistory { get; set; }
        public bool IsGuestActive { get; set; }
        public List<Reservation>? Reservations { get; set; }

    }
}
