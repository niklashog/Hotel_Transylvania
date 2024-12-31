using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Spectre.Console;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class DeactivateReservation(
        IReservationService reservationService) : IDeactivateReservation
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            var listOfActiveReservations = dbContext.Reservations
                .Where(r => r.IsReservationActive)
                .ToList();

            var numberOfActiveReservations = listOfActiveReservations
                .Count();

            var validReservationIds = listOfActiveReservations
                .Select(r => r.Id)
                .ToList();

            if (numberOfActiveReservations <= 0)
            {
                Console.WriteLine("There are no active guests in the system.\n" +
                    "Press any key to go back.");
            }
            else
            {
                reservationService.ShowReservations(dbContext);

                Console.CursorVisible = true;
                AnsiConsole.MarkupLine("[bold yellow]Deactivate Reservation[/]");

                string reservationIdForDeactivation = AnsiConsole.Prompt(
                    new TextPrompt<string>("Input [yellow]Reservation Id[/] to deactivate:")
                        .ValidationErrorMessage("[red]Please enter a valid Reservation Id[/]")
                        .Validate(input =>
                        {
                            if (!int.TryParse(input, out int reservationId))
                            {
                                return ValidationResult.Error("[red]Reservation Id has to be a number[/]");
                            }

                            if (!validReservationIds.Contains(reservationId))
                            {
                                return ValidationResult.Error("[red]Reservation Id doesn't exist or is already inactive.[/]");
                            }

                            return ValidationResult.Success();
                        })
                        );

                Console.CursorVisible = false;

                bool confirm = AnsiConsole.Confirm("\nPlease confirm this is the correct reservation to cancel.");

                if (confirm)
                {
                    reservationService.RemoveReservation(reservationIdForDeactivation, dbContext);
                    AnsiConsole.MarkupLine("[bold green]Reservation cancelled and is no longer active.[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Nothing was cancelled. Reservation is still active.[/]");

                }
            }
            Console.ReadKey();
        }
    }
}
