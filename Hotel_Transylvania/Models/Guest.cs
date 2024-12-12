using Hotel_Transylvania.Interfaces.ModelsInterfaces;

namespace Hotel_Transylvania.Models
{
    public class Guest : IGuest
    {
        public int GuestID { get; set; }
        public int NextGuestID { get; set; } = 1;
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ReservationHistory { get; set; }
        public bool IsGuestActive { get; set; } = true;

        //public static List<IGuest> ListOfGuests { get; set; } = new List<IGuest>();

    }
}
