using System.ComponentModel.DataAnnotations;

namespace Hotel_Transylvania.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public bool IsGuestActive { get; set; } = true;
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
    }
}