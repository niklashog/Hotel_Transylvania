using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;

namespace Hotel_Transylvania.Menus
{
    public class ReservationMenu(
        ICalendarNavigation calendar) : INewReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            var currentDate = DateTime.Now.Date;
            var checkInDate = calendar.CalendarNavigate("CheckIn─Date", currentDate);
            var checkOutDate = calendar.CalendarNavigate("CheckOut─Date", checkInDate);

            Console.WriteLine(
                $"Confirm reservation from " +
                $"{checkInDate.Year}-{checkInDate.Month}-{checkInDate.Day} to " +
                $"{checkOutDate.Year}-{checkOutDate.Month}-{checkOutDate.Day}?");
            Console.ReadKey();
        }
    }
}