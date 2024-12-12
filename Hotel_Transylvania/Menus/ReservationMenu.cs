using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;

namespace Hotel_Transylvania.RealMenus
{
    public class ReservationMenu(
        ICalendarNavigation calendar) : INewReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            var checkInDate = calendar.CalendarNavigate("CheckIn─Date");
            var checkOutDate = calendar.CalendarNavigate("CheckOut─Date");
            Console.WriteLine($"Confirm reservation from {checkInDate} to {checkOutDate}?");
            Console.ReadKey();
        }
    }
}
