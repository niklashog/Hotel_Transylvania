using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class ChangeReservation : IChangeReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I CHANGE RESERVATIONS");
            Console.ReadKey();
        }
    }
}
