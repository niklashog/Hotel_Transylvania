using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace Hotel_Transylvania.Menus.Guests
{
    public class UpdateGuest(
        IGuestService guestService) : IUpdateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            guestService.DisplayActiveGuests(dbContext);

            Console.CursorVisible = true;

            var activeGuests = guestService.ListOfActiveGuests(dbContext);
            var validGuestIds = activeGuests
                .Select(g => g.Id)
                .ToList();

            Console.CursorVisible = true;
            AnsiConsole.MarkupLine("[bold yellow]Update Guest Details[/]");

            string guestToUpdateInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]Guest to update: [/]:")
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
            var guestToUpdate = int.Parse(guestToUpdateInput);

            Console.CursorVisible = false;

            Console.Clear();
            DisplayLogo.Paint();

            guestService.DisplayGuestDetails(guestToUpdate, dbContext);

            string firstNameInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]First Name[/]:")
                    .ValidationErrorMessage("[red]First Names can only consist of letters.[/]")
                    .Validate(input =>
                    {
                        if (Regex.IsMatch(input, @"^[\p{L}]{2,20}-?$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Names cannot include numbers or special characters and can only be 20 characters long. Try again.[/]");
                        }
                    })
                    );

            string surnameInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]Surname[/]:")
                    .ValidationErrorMessage("[red]Surnames can only consist of letters.[/]")
                    .Validate(input =>
                    {
                        if (Regex.IsMatch(input, @"^[\p{L}]{2,50}-?$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Surnames cannot include numbers or special characters and can only be 50 characters long. Try again.[/]");
                        }
                    })
                    );

            string emailInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]E-mail Adress (required)[/]:")
                    .ValidationErrorMessage("[red]Please enter a correct e-mail adress[/]")
                    .Validate(input =>
                    {
                        if (Regex.IsMatch(input, @"^[a-zA-Z0-9._%+\-]{2,}@[a-zA-Z0-9.\-]{2,}\.[a-zA-Z]{2,}$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Each part of the e-mail adress must be at least 2 characters long (e.g. bo@ek.se). Try again.[/]");
                        }
                    })
                    );

            string phoneInput = AnsiConsole.Prompt(
                new TextPrompt<string?>("Input [yellow]Phone Number[/] (optional):")
                    .AllowEmpty()
                    .ValidationErrorMessage("[red]Please enter a correct phone number[/]")
                    .Validate(input =>
                    {
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("Phone number left blank.");
                            return ValidationResult.Success();
                        }
                        if (Regex.IsMatch(input, @"^(?=.{1,20}$)\+{0,1}\d+(-?\d+)*(\(\d+\))?$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Enter a valid phone number or leave blank. Try again.[/]");
                        }
                    })
                    );

            Console.CursorVisible = false;
            Console.Clear();
            DisplayLogo.Paint();

            var currentGuestDetails = guestService.GetGuestById(guestToUpdate, dbContext);

            var updatedGuestDetails = new string[]
            {
                firstNameInput,
                surnameInput,
                emailInput,
                phoneInput ?? "-"
            };

            AnsiConsole.MarkupLine("\n[bold yellow]Summary:[/]");
            var table = new Table();
            table.AddColumn("[yellow]Guest detail[/]");
            table.AddColumn("[yellow]Current[/]");
            table.AddColumn("[yellow]New[/]");
            table.AddRow("First Name:", currentGuestDetails.FirstName, firstNameInput);
            table.AddRow("Surname:", currentGuestDetails.Surname, surnameInput);
            table.AddRow("E-mail:", currentGuestDetails.Email, emailInput);
            table.AddRow("Phone:", currentGuestDetails.Phone, phoneInput);
            AnsiConsole.Write(table);

            bool confirm = AnsiConsole.Confirm("\nConfirm new details are correct");

            if (confirm)
            {
                AnsiConsole.MarkupLine("[bold green]Guest successfully edited![/]");
                guestService.UpdateGuestDetails(guestToUpdate, updatedGuestDetails, dbContext);
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Cancelled. Details remain unchanged.[/]");
            }

            Console.ReadKey();

        }
    }
}
