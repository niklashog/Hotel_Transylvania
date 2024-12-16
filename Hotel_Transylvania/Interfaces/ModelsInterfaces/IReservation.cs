using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.ModelsInterfaces
{
    public interface IReservation
    {
        public int ReservationID { get; set; }
        public int RoomNumber { get; set; }
        public int GuestID { get; set; }
        public int NumberOfAdditionalBeds { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime TimeOfReservation { get; set; }
        public bool IsReservationActive { get; set; }
    }
}
