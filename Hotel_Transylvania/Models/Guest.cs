
namespace Hotel_Transylvania.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int? ReservationHistory { get; set; }
        public bool IsGuestActive { get; set; } = true;
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}