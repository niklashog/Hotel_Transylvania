using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces
{
    public interface IGuest
    {
        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NumberOfReservations { get; set; }
        public bool IsGuestActive { get; set; }
    }
}
