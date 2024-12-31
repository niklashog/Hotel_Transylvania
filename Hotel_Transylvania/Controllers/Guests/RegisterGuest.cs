using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Spectre.Console;


namespace Hotel_Transylvania.Menus.Guests
{
    public class RegisterGuest(
        IGuestService guestService) : IRegisterGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            string firstNameInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]First Name[/]:")
                    .ValidationErrorMessage("[red]First Names can only consist of letters.[/]")
                    .Validate(input =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^[\p{L}]{2,20}(-[\p{L}]{1,17})?$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Names cannot include numbers or special characters with a max length of 20 letters. Try again.[/]");
                        }
                    })
                    );

            string surnameInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]Surname[/]:")
                    .ValidationErrorMessage("[red]Surnames can only consist of letters.[/]")
                    .Validate(input =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^[\p{L}]{2,20}(-[\p{L}]{1,47})?$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Surnames cannot include numbers or special characters with a max length of 50 letters. Try again.[/]");
                        }
                    })
                    );

            string emailInput = AnsiConsole.Prompt(
                new TextPrompt<string>("Input [yellow]E-mail Adress[/]:")
                    .ValidationErrorMessage("[red]Please enter a correct e-mail adress[/]")
                    .Validate(input =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9._%+\-]{2,}@[a-zA-Z0-9.\-]{2,}\.[a-zA-Z]{2,}$"))
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
                new TextPrompt<string?>("Input [yellow]Phone Number[/]:")
                    .AllowEmpty()
                    .ValidationErrorMessage("[red]Please enter a correct phone number[/]")
                    .Validate(input =>
                    {
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("Phone number left blank.");
                            return ValidationResult.Success();
                        }
                        if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^(?=.{1,20}$)\+{0,1}\d+(-?\d+)*(\(\d+\))?$"))
                        {
                            return ValidationResult.Success();
                        }
                        else
                        {
                            return ValidationResult.Error("[red]Enter a valid phone number or leave blank. Try again.[/]");
                        }
                    })
                    );

            //Slår på denna när jag har implementerat date of birth i Guest

            //string birthInput = AnsiConsole.Prompt(
            //    new TextPrompt<string>("Input [yellow]date of birth (yyyy-mm-dd)[/]:")
            //        .ValidationErrorMessage("[red]You can only input digits.[/]")
            //        .Validate(input =>
            //        {
            //            return DateTime.TryParseExact(
            //                input,
            //                "yyyy-MM-dd",
            //                System.Globalization.CultureInfo.InvariantCulture,
            //                System.Globalization.DateTimeStyles.None,
            //                out _)
            //                ? ValidationResult.Success()
            //                : ValidationResult.Error("[red]Please input date of birth as yyyy-mm-dd. Try again.[/]");
            //        })
            //        );


            bool confirm = AnsiConsole.Confirm("\nIs the above information correct?");

            if (confirm)
            {
                AnsiConsole.MarkupLine("[green]Registration successful.[/]");

                var newGuest = new Guest
                {
                    FirstName = firstNameInput,
                    Surname = surnameInput,
                    Email = emailInput,
                    Phone = phoneInput ?? "-"
                };
                guestService.AddGuest(newGuest, dbContext);
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Registration cancelled.[/]");
            }

            Console.CursorVisible = false;
            Console.ReadKey();




        }
    }
}
