using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class RegisterNewRoom(
        IRoomService roomService) : IRegisterNewRoom
    {
        public void Execute()
        {
            var newRoom = MainFactory.Resolve<Room>();
            using var dbContext = ApplicationDbContext.GetDbContext();

            var existingRoomNumbers = roomService.GetExistingRoomNumbersAsString(dbContext);

            Console.Clear();
            DisplayLogo.Paint();

            AnsiConsole.MarkupLine($"[bold yellow]Current Room Numbers[/]");
            foreach (var roomNumber in existingRoomNumbers)
            {
                AnsiConsole.Markup($"{roomNumber} ");
            }

            Console.WriteLine("\n");
            Console.CursorVisible = true;
            string roomNumberInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]Room Number:[/]")
                    .ValidationErrorMessage("[red]Room Number can only contain a maximum of three digits.[/]")
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

            string roomTypeInput = AnsiConsole.Prompt(
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

            string roomSizeInput = AnsiConsole.Prompt(
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

            Console.CursorVisible = false;
            newRoom.RoomNumber = Convert.ToInt32(roomNumberInput);
            newRoom.RoomType = roomTypeInput;
            newRoom.RoomSize = Convert.ToInt32(roomSizeInput);

            roomService.AddRoom(newRoom, dbContext);
            Console.ReadKey();
        }
    }
}
