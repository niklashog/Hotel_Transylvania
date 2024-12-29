using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ReactivateRoom(
        IRoomService roomService) : IReactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();


            if (roomService.GetAllRooms(dbContext)
                .Where(g => g.IsRoomActive == false)
                .ToList()
                .Count >= 1)
            {
                roomService.DisplayInactiveRooms(dbContext);

                var inactiveRooms = dbContext.Rooms
                .Where(g => g.IsRoomActive == false)
                .ToList();

                var validRoomNumbers = inactiveRooms
                    .Select(r => r.RoomNumber)
                    .ToList();

                Console.CursorVisible = true;
                AnsiConsole.MarkupLine("[bold yellow]Reactivate Room[/]");

                string roomToReactivateString = AnsiConsole.Prompt(
                    new TextPrompt<string>("Input [yellow]Room Number[/] to reactivate:")
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
                var roomToReactivate = int.Parse(roomToReactivateString);

                bool confirm = AnsiConsole.Confirm("\nPlease confirm this is the correct room to reactivate.");

                if (confirm)
                {
                    AnsiConsole.MarkupLine($"[green]Success! Room is now active.[/]");
                    roomService.ReActivateRoom(roomToReactivate, dbContext);
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Nothing was reactivated. Room is still inactive.[/]");
                }
            }
            else
            {
                AnsiConsole.WriteLine("There are no inactive rooms in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
        }
    }
}
