using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces
{
    public interface IReservation
    {
        public string PrimaryGuest { get; set; }
        public int SizeOfParty { get; set; }
        public int NumberOfRooms { get; set; }
        public bool NeedsAdditionalBedding { get; set; }
        public int NumberOfAdditionalBeds { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime TimeOfReservation { get; set; }
        public bool IsReservationActive { get; set; }
    }
}
