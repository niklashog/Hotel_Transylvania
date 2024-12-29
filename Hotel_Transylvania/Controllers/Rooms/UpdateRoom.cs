using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class UpdateRoom(
        IRoomService roomService) : IUpdateRoom
    {
        public void Execute()
        {
            using var dbContext = ApplicationDbContext.GetDbContext();

            Console.Clear();
            DisplayLogo.Paint();

            if (roomService.GetAllRooms(dbContext)
                .ToList()
                .Count >= 1)
            {
                roomService.DisplayActiveRooms(dbContext);

                var listOfAllRooms = roomService.GetAllRooms(dbContext)
                .ToList();

                var validRoomNumbersToUpdate = listOfAllRooms
                    .Select(r => r.RoomNumber)
                    .ToList();

                Console.CursorVisible = true;
                AnsiConsole.MarkupLine("[bold yellow]Update Room Details[/]");

                string roomToUpdateString = AnsiConsole.Prompt(
                    new TextPrompt<string>("Input [yellow]Room Number[/] of room you want to update:")
                        .ValidationErrorMessage("[red]Please enter an existing Room Number[/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int roomNumber))
                            {
                                return ValidationResult.Error("[red]Room Numbers only contain digits. Try again.[/]");
                            }

                            if (!validRoomNumbersToUpdate.Contains(roomNumber))
                            {
                                return ValidationResult.Error("[red]Please input a room number from the list.[/]");
                            }
                            return ValidationResult.Success();
                        })
                        );

                var roomToUpdate = int.Parse(roomToUpdateString);
                
                Console.Clear();
                DisplayLogo.Paint();

                roomService.DisplaySingleRoom(roomToUpdate, dbContext);

                string roomTypeString = AnsiConsole.Prompt(
                    new TextPrompt<string>("Input [yellow]Room Type[/]:")
                        .ValidationErrorMessage("[red]Room can only be of type: Single, Double or Suite.[/]")
                    .Validate(input =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^(Single|Double|Suite)$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Please only input type as one of the three options: Single, Double or Suite.[/]");
                        }
                    })
                    );

                string roomSizeString = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]Room Size (m²)[/]:")
                    .ValidationErrorMessage("[red]Rooms can only be of 8-34m² in size.[/]")
                    .Validate(input =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^(8|9|[1-2]\d|3[0-4])$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Please only use digits and keep room size between 8-34m².[/]");
                        }
                    })
                    );
                
                var newRoomNumber = roomToUpdate;

                bool confirm = AnsiConsole.Confirm($"Do you want to leave the room number unchanged?");
                if (confirm)
                {
                }
                else
                {
                    Console.WriteLine("");
                    AnsiConsole.MarkupLine($"[bold yellow]Current Room Numbers[/]");
                    var existingRoomNumbers = roomService.GetExistingRoomNumbersAsString(dbContext);
                    foreach (var i in existingRoomNumbers)
                    {
                        AnsiConsole.Markup($"{i} ");
                    }
                    Console.WriteLine("\n");
                    string roomNumberString = AnsiConsole.Prompt(
                        new TextPrompt<string>("Input new [yellow]Room Number:[/]")
                        .Validate(input =>
                        {
                            if (existingRoomNumbers.Contains(input))
                            {
                                return ValidationResult.Error("[red]Room with that number already exists.[/]");

                            }
                            if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^[1-9]\d{2}$"))
                            {
                                return ValidationResult.Success();
                            }
                            else
                            {
                                return ValidationResult.Error("[red]Room Numbers can only contain digits, must be 3 digits long, and cannot start with a 0.[/]");
                            }
                        })
                        );
                    newRoomNumber = int.Parse(roomNumberString);
                }

                Console.Clear();
                DisplayLogo.Paint();

                var currentRoomDetails = roomService.GetAllRooms(dbContext)
                    .First(r => r.RoomNumber == roomToUpdate);

                var newRoomType = roomTypeString;
                var newRoomSize = int.Parse(roomSizeString);

                var updatedRoomDetails = new Room
                {
                    RoomNumber = newRoomNumber,
                    RoomType = newRoomType,
                    RoomSize = newRoomSize,
                };

                var table = new Table();
                table.AddColumn("[yellow]Room detail[/]");
                table.AddColumn("[yellow]Current[/]");
                table.AddColumn("[yellow]New[/]");
                table.AddRow("Room Number:", currentRoomDetails.RoomNumber.ToString(), updatedRoomDetails.RoomNumber.ToString());
                table.AddRow("Room Type:", currentRoomDetails.RoomType, updatedRoomDetails.RoomType);
                table.AddRow("Room Size:", currentRoomDetails.RoomSize.ToString(), updatedRoomDetails.RoomSize.ToString());
                AnsiConsole.Write(table);

                bool finalConfirm = AnsiConsole.Confirm("\nConfirm new details are correct");

                if (finalConfirm)
                {
                    AnsiConsole.MarkupLine("[bold green]Room successfully edited![/]");
                    roomService.UpdateRoomDetails(roomToUpdate, updatedRoomDetails, dbContext);
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Cancelled. Details remain unchanged.[/]");
                }
                
                Console.CursorVisible = false;
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.WriteLine("There are no active rooms in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
        }
    }
}
