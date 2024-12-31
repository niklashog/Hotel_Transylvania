using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class DeactivateRoom(
        IRoomService roomService,
        IReservationService reservationService) : IDeactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();


            if (roomService.GetAllRooms(dbContext)
                .Where(g => g.IsRoomActive)
                .ToList()
                .Count >= 1)
            {
                roomService.DisplayActiveRooms(dbContext);

                var activeRooms = dbContext.Rooms
                .Where(g => g.IsRoomActive)
                .ToList();

                var validRoomNumbers = activeRooms
                    .Select(r => r.RoomNumber)
                    .ToList();

                var listOfActiveReservations = reservationService.GetListOfAllReservations(dbContext)
                    .Where(r => r.IsReservationActive)
                    .ToList();

                Console.CursorVisible = true;
                AnsiConsole.MarkupLine("[bold yellow]Deactivate Room[/]");

                string roomToDeactivateString = AnsiConsole.Prompt(
                    new TextPrompt<string>("Input [yellow]Room Number[/] to deactivate:")
                        .ValidationErrorMessage("[red]Please enter an existing Room Number[/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int roomNumber))
                            {
                                return ValidationResult.Error("[red]Room Numbers only contain digits. Try again.[/]");
                            }

                            if (!validRoomNumbers.Contains(roomNumber))
                            {
                                return ValidationResult.Error("[red]Please input a room number from the list.[/]");
                            }
                            return ValidationResult.Success();
                        })
                        );

                Console.CursorVisible = false;
                var roomToDeactivate = int.Parse(roomToDeactivateString);

                bool confirm = AnsiConsole.Confirm("\nPlease confirm this is the correct room to deactivate.");

                if (confirm)
                {
                    roomService.RemoveRoom(roomToDeactivate, listOfActiveReservations, dbContext);
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Nothing was cancelled. Everything is still active.[/]");
                }
            }
            else
            {
                AnsiConsole.WriteLine("There are no active rooms in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
        }
    }
}