using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Interfaces.ToolsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Interfaces.ControllerInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Data;

namespace Hotel_Transylvania.Controllers.Reservations
{
    public class AddReservation(
        IGuestService guestService,
        IReservationService reservationService,
        ICalendarNavigation calendar
        ) : IAddReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            var xcoord = 45;
            var ycoord = 8;
            guestService.DisplayActiveGuests(dbContext);

            Console.CursorVisible = true;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Make reservation by Guest Id..");
            Console.SetCursorPosition(2, 9);
            Console.Write("Guest ID: ");
            var guestIdToBook = Convert.ToInt32(Console.ReadLine());

            Console.CursorVisible = false;
            Console.Write($"\nPress any key to chose dates for reservation.");
            Console.ReadKey();

            Console.Clear();
            DisplayLogo.Paint();
            var currentDate = DateTime.Now.Date;
            var checkInDate = calendar.CalendarNavigate("CheckIn─Date", currentDate);
            var checkOutDate = calendar.CalendarNavigate("CheckOut─Date", checkInDate);

            
            var availableRooms = reservationService.GetAvailableRooms(checkInDate, checkOutDate, dbContext)
                .ToList();
            Console.WriteLine("Available Rooms");
            foreach (var room in availableRooms)
            {
                Console.WriteLine($"#{room.RoomNumber}, {room.RoomType}, {room.RoomSize}m²");
            }


            Console.WriteLine("Which room do you want stay in?");
            var roomNumberChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
                $"Confirm reservation from " +
                $"{checkInDate.Year}-{checkInDate.Month}-{checkInDate.Day} to " +
                $"{checkOutDate.Year}-{checkOutDate.Month}-{checkOutDate.Day}?");
            Console.ReadKey();

            reservationService.AddReservation(guestIdToBook, checkInDate, checkOutDate, roomNumberChoice, dbContext);
            Console.WriteLine("Reservation complete. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
