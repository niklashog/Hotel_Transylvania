using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Models;
using System.Threading.Channels;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Guests
{
    public class DeactivateGuest(
        IGuestService guestService) : IDeactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();


            if (guestService.GetAllGuests(dbContext)
                .Where(g => g.IsGuestActive)
                .ToList()
                .Count >= 1)
            {
                guestService.DisplayActiveGuests(dbContext);
                
                var activeGuests = guestService.ListOfActiveGuests(dbContext);
                var validGuestIds = activeGuests
                    .Select(g => g.Id)
                    .ToList();

                Console.CursorVisible = true;
                AnsiConsole.MarkupLine("[bold yellow]Deactivate Guest[/]");

                string guestToDeactivate = AnsiConsole.Prompt(
                    new TextPrompt<string>("[yellow]Guest to deactivate: [/]:")
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

                bool confirm = AnsiConsole.Confirm("\nPlease confirm this is the correct guest to inactivate.");

                if (confirm)
                {
                    guestService.RemoveGuest(guestToDeactivate, dbContext);
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Nothing was cancelled. Everything is still active.[/]");
                }
            }
            else
            {
                AnsiConsole.WriteLine("There are no active guests in the system." +
                    "\nPress any key to go back.");
                return;
            }
            Console.ReadKey();

        }
    }

}
