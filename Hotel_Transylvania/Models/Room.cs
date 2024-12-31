namespace Hotel_Transylvania.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }
        public int AdditionalBeddingNumber { get; set; }
        public bool IsRoomActive { get; set; } = true;
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}