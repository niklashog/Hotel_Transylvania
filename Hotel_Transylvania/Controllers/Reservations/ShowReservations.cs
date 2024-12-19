using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
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

            var dbContext = ApplicationDbContext.GetDbContext();
            
            reservationService.ShowReservations(dbContext);

            //reservationService.ShowInactiveReservations(dbContext);

            Console.ReadKey();
        }
    }
}
