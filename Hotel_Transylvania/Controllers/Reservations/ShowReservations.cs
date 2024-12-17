using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;


namespace Hotel_Transylvania.Menus.Reservations
{
    public class ShowReservations(
        IReservationService reservationService) : IShowReservations
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            reservationService.ShowReservations();

            Console.ReadKey();
        }
    }
}
