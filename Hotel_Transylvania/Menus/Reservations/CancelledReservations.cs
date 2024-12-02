using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class CancelledReservations : ICancelledReservations
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I SHOW CANCELLED RESERVATIONS");
            Console.ReadKey();
        }
    }
}
