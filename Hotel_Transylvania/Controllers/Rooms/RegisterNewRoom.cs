using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Microsoft.EntityFrameworkCore.Query;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class RegisterNewRoom(
        IRoomService roomService) : IRegisterNewRoom
    {
        public void Execute()
        {
            var newRoom = MainFactory.Resolve<Room>();
            using var dbContext = ApplicationDbContext.GetDbContext();

            Console.Clear();
            DisplayLogo.Paint();
            Console.CursorVisible = true;

            string roomNumberInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]Room Number[/]:")
                    .ValidationErrorMessage("[red]Room Number can only contain a maximum of three digits.[/]")
                    .Validate(input =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^[1-9]\d{2}$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Room Numbers cannot consist of letters and must be exactly three digits long.[/]");
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

            roomService.AddRoom(dbContext, newRoom);
            Console.ReadKey();
        }
    }
}
