using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class CancelReservation : ICancelReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I CANCEL RESERVATIONS");
            Console.ReadKey();
        }
    }
}
