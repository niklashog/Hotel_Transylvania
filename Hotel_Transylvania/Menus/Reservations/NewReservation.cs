using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class NewReservation : INewReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I HAS NEW  RESERVATION");
            Console.ReadKey();
        }
    }
}
