using Hotel_Transylvania.Interfaces;

namespace Hotel_Transylvania
{
    public class Guest : IGuest
    {
        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NumberOfReservations { get; set; }
        public bool IsGuestActive { get; set; } = true;
        public static List<IGuest> ListOfAllGuests { get; set; } = new List<IGuest>();
    }
}
