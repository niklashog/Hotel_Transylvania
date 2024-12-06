using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class NewReservation(
        ICalendarNavigation calendar) : INewReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            var checkInPromt = " CheckIn-Date ";
            var checkInDate = calendar.CalendarNavigate(checkInPromt);
            var checkOutPromt = " CheckOut-Date ";
            var checkOutDate = calendar.CalendarNavigate(checkOutPromt);
            Console.WriteLine($"Confirm reservation from {checkInDate} to {checkOutDate}?");
            Console.ReadKey();
        }
    }
}
