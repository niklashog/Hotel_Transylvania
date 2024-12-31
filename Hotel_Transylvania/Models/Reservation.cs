namespace Hotel_Transylvania.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfAdditionalBeds { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime TimeOfReservation { get; set; } = DateTime.Now.Date;
        public bool IsReservationActive { get; set; } = true;
        public ICollection<Guest>? Guests { get; set; } = new List<Guest>();
        public ICollection<Room>? Rooms { get; set; } = new List<Room>();
    }
}