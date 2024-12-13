using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Services;

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
