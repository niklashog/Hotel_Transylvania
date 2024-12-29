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
using Spectre.Console;

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

            guestService.DisplayActiveGuests(dbContext);

            var activeGuests = guestService.ListOfActiveGuests(dbContext);
            var validGuestIds = activeGuests
                .Select(g => g.Id)
                .ToList();

            Console.CursorVisible = true;
            string guestIdToBook = AnsiConsole.Prompt(
                    new TextPrompt<string>("Make reservation by [yellow]Guest Id[/]:")
                        .ValidationErrorMessage("[red]Please enter an existing Guest Id[/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int guestId))
                            {
                                return ValidationResult.Error("[red]Guest Id's only contain numbers. Try again.[/]");
                            }

                            if (!validGuestIds.Contains(guestId))
                            {
                                return ValidationResult.Error("[red]Guest Id doesn't exist. Try again.[/]");
                            }

                            return ValidationResult.Success();
                        })
                        );

            Console.CursorVisible = false;

            Console.Write($"\nPress any key to chose dates for reservation.");
            Console.ReadKey();

            Console.Clear();
            DisplayLogo.Paint();
            var currentDate = DateTime.Now.Date;
            var checkInDate = calendar.CalendarNavigate(reservationService.CheckInCalendarHeader(), currentDate, reservationService.CheckInCalendarPrompt());
            var checkOutDate = calendar.CalendarNavigate(reservationService.CheckOutCalendarHeader(), checkInDate, reservationService.CheckOutCalendarPrompt());

            Console.Clear();
            DisplayLogo.Paint();

            Console.CursorVisible = true;

            reservationService.DisplayAvailableRoomsForReservations(checkInDate, checkOutDate, dbContext);
            
            var activeRooms = reservationService.GetAvailableRooms(checkInDate, checkOutDate, dbContext);
            var validRoomNumbers = activeRooms
                .Select(r => r.RoomNumber)
                .ToList();

            Console.CursorVisible = true;
            AnsiConsole.MarkupLine("[bold yellow]Available rooms[/]");

            string roomNumberChoice = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter a [yellow]room number[/] for the reservation: ")
                    .ValidationErrorMessage("[red]Please enter a valid room number[/]")
                    .Validate(input =>
                    {
                        if (!int.TryParse(input, out int roomNumber))
                        {
                            return ValidationResult.Error("[red]Room numbers only contain digits. Try again.[/]");
                        }

                        if (!validRoomNumbers.Contains(roomNumber))
                        {
                            return ValidationResult.Error("[red]Please chose one of the available rooms.[/]");
                        }

                        return ValidationResult.Success();
                    })
                    );

            Console.CursorVisible = false;

            Console.WriteLine(
                $"Reservation made from " +
                $"{checkInDate.Year}-{checkInDate.Month}-{checkInDate.Day} to " +
                $"{checkOutDate.Year}-{checkOutDate.Month}-{checkOutDate.Day} \n" +
                $"Press any key to continue.");
            Console.ReadKey();

            var timeOfReservation = DateTime.Now;
            reservationService.AddReservation(guestIdToBook, checkInDate, checkOutDate, roomNumberChoice, dbContext);
        }
    }
}
