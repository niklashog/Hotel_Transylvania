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


            var availableRooms = reservationService.GetAvailableRooms(checkInDate, checkOutDate, dbContext)
                .ToList();

            var validRoomNumbers = availableRooms
                .Select(r => r.RoomNumber);

            reservationService.DisplayAvailableRoomsForReservations(checkInDate, checkOutDate, availableRooms, dbContext);
            


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

            var additionalBeddingNumber = 0;
            var chosenRoom = availableRooms
                .Where(r => r.RoomNumber == int.Parse(roomNumberChoice))
                .FirstOrDefault();

            if (chosenRoom.AdditionalBeddingNumber > 0)
            {
                AnsiConsole.MarkupLine($"Need of additional bedding?");
                bool confirm = AnsiConsole.Confirm("Press 'y' for yes or 'n' for no.");

                if (confirm && chosenRoom.AdditionalBeddingNumber == 2)
                {
                    var listOfValidChoicesForExtraBeds = new List<int> { 1, 2 };

                    string oneOrTwoBedsString = AnsiConsole.Prompt(
                        new TextPrompt<string>("[yellow]One or two beds needed? Input as single digit.[/]")
                            .ValidationErrorMessage("[bold red]Please enter a number for additional bedding.[/]")
                    .Validate(input =>
                    {
                        if (!int.TryParse(input, out int oneOrTwoBedsString))
                        {
                            return ValidationResult.Error("[bold red]Extra beds must be input as a number[/]");
                        }

                        if (!listOfValidChoicesForExtraBeds.Contains(oneOrTwoBedsString))
                        {
                            return ValidationResult.Error("[bold red]Choice can only be made of between 1 and 2.[/]");

                        }
                        return ValidationResult.Success();
                    })
                    );
                    additionalBeddingNumber = int.Parse(oneOrTwoBedsString);
                    AnsiConsole.MarkupLine($"[green]Additional bedding set to {additionalBeddingNumber}[/]");
                }
                if (confirm && chosenRoom.AdditionalBeddingNumber == 1)
                {
                    additionalBeddingNumber = 1;
                    AnsiConsole.MarkupLine($"[green]Additional bedding set to {additionalBeddingNumber}[/]");
                }
            }

            Console.CursorVisible = false;


            Console.WriteLine(
                $"Reservation made from " +
                $"{checkInDate.Year}-{checkInDate.Month}-{checkInDate.Day} to " +
                $"{checkOutDate.Year}-{checkOutDate.Month}-{checkOutDate.Day} \n" +
                $"Press any key to continue.");
            Console.ReadKey();

            reservationService.AddReservation(guestIdToBook, checkInDate, checkOutDate, roomNumberChoice, additionalBeddingNumber, dbContext);
        }
    }
}
