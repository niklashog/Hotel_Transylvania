using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using System.Text.RegularExpressions;


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


            Console.CursorVisible = true;
            Console.WriteLine("Enter guest details..");
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            Console.Write("E-mail: ");
            var emailInput = Console.ReadLine();

            string email;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (Regex.IsMatch(emailInput, emailPattern))
            {
                email = emailInput;
            }
            else
            {
                Console.CursorVisible = false;
                Console.WriteLine("Enter a valid e-mail adress.");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                return;
            }

            string phone = null;
            string phonePattern = @"^\+{0,2}\d+(-?\d+)*(\(\d+\))?$";

            while (true)
            {
                Console.Write("Phone number: ");
                var phoneInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(phoneInput))
                {
                    phoneInput = null;
                    Console.WriteLine("Phone number left blank.");
                    break;
                }

                if (Regex.IsMatch(phoneInput, phonePattern))
                {
                    phone = phoneInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid phone number.");
                    Console.Write("Press any key to try again.");
                    Console.ReadKey();
                }
            }

            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();

            int guestCount = guestService.GetAllGuests(dbContext).Count();
            var setGuestId = ++guestCount;
            Console.WriteLine(guestCount);

            var newGuest = new Guest
            {
                FirstName = firstName,
                Surname = surname,
                Email = email,
                Phone = phone ?? "---"
            };

            guestService.AddGuest(newGuest, dbContext);
        }
    }
}
