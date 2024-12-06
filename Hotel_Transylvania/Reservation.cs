using Hotel_Transylvania.Interfaces;

namespace Hotel_Transylvania
{
    public class Reservation : IReservation
    {
        public string PrimaryGuest { get; set; }
        public int SizeOfParty { get; set; }
        public int NumberOfRooms { get; set; }
        public bool NeedsAdditionalBedding { get; set; }
        public int NumberOfAdditionalBeds { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime TimeOfReservation { get; set; } = DateTime.Now;
        public bool IsReservationActive { get; set; } = true;
        public static List<IReservation> ListOfAllReservations { get; set; } = new List<IReservation>();
    }
}
