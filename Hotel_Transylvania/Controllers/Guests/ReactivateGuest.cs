using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;
using Hotel_Transylvania.Data;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ReactivateGuest(
        IGuestService guestService) : IReactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();


            if (guestService.GetAllGuests(dbContext)
                .Where(g => g.IsGuestActive == false)
                .ToList()
                .Count >= 1)
            {
                guestService.DisplayInactiveGuests(dbContext);


                var inactiveGuests = guestService.ListOfInctiveGuests(dbContext);
                var validGuestIds = inactiveGuests
                .Select(g => g.Id)
                .ToList();

                Console.CursorVisible = true;
                AnsiConsole.MarkupLine("[bold yellow]Reactivate Guest[/]");

                string guestToReactivate = AnsiConsole.Prompt(
                    new TextPrompt<string>("[yellow]Guest Id[/] to reactivate:")
                        .ValidationErrorMessage("[red]Please enter an existing Guest Id[/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int guestId))
                            {
                                return ValidationResult.Error("[red]Guest Id has to be a number[/]");
                            }

                            if (!validGuestIds.Contains(guestId))
                            {
                                return ValidationResult.Error("[red]Guest Id doesn't exist[/]");
                            }

                            return ValidationResult.Success();
                        })

                        );

                Console.CursorVisible = false;

                bool confirm = AnsiConsole.Confirm("\nPlease confirm this is the correct guest to reactivate.");

                if (confirm)
                {
                    guestService.ReActivateGuest(guestToReactivate, dbContext);
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Cancelled..[/]");
                }
            }
            else
            {
                AnsiConsole.WriteLine("There are no inactive guests in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
        }
    }
}
