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
            var checkInPromt = "Check-In Date";
            var checkInDate = calendar.CalendarNavigate(checkInPromt);
            Console.WriteLine("New reservation to: ");
            var checkOutPromt = "Check-Out Date";
            var checkOutDate = calendar.CalendarNavigate(checkOutPromt);
            Console.WriteLine($"Confirm reservation from {checkInDate} to {checkOutDate}?");
            Console.ReadKey();
        }
    }
}
