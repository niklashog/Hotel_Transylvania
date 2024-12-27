using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Data;
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
            Console.WriteLine("Update guest details. Leaving a field blank will keep current data.");
                        
            int guestToUpdate;
            string guestToUpdatePattern = "^[0-9]+$";
            while (true)
            {
                Console.Write("Guest Id: ");
                var guestToUpdateInput = Console.ReadLine();

                if (Regex.IsMatch(guestToUpdateInput, guestToUpdatePattern))
                {
                    guestToUpdate = int.Parse(guestToUpdateInput);
                    break;
                }
                else
                {
                    Console.WriteLine("Only digits are allowed. Try again.");
                }
            }

            Console.CursorVisible = false;

            Console.Clear();
            DisplayLogo.Paint();

            guestService.PrintGuestDetails(guestToUpdate, dbContext);

            string firstName;
            string firstNamePattern = @"^[\p{L}]+$";
            while (true)
            {
                Console.Write("\nNew First Name: ");
                var firstNameInput = Console.ReadLine();

                if (Regex.IsMatch(firstNameInput, firstNamePattern))
                {

                    firstName = firstNameInput;
                    break;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("Names cannot include numbers or special characters. Try again.");
                }
            }

            string surname;
            string surnamePattern = @"^[\p{L}]+$";
            while (true)
            {
                Console.Write("New Surname: ");
                var surnameInput = Console.ReadLine();

                if (Regex.IsMatch(surnameInput, surnamePattern))
                {
                    surname = surnameInput;
                    break;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("Names cannot include numbers or special characters. Try again.");
                }
            }


            string email;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            while (true)
            {
                Console.Write("New E-mail: ");
                var emailInput = Console.ReadLine();

                if (Regex.IsMatch(emailInput, emailPattern))
                {
                    email = emailInput;
                    break;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.WriteLine("Enter a valid e-mail adress (required).");
                }
            }

            string phone = null;
            string phonePattern = @"^\+{0,2}\d+(-?\d+)*(\(\d+\))?$";
            while (true)
            {
                Console.Write("New Phone number: ");
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
                    Console.WriteLine("Enter a valid phone number or leave blank.");
                }
            }

            Console.CursorVisible = false;
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();

            var currentGuestDetails = guestService.GetGuestById(guestToUpdate, dbContext);


            var updatedGuestDetails = new string[]
            {
                firstName,
                surname,
                email,
                phone ?? "---"
            };

            guestService.UpdateGuestDetails(guestToUpdate, updatedGuestDetails, dbContext);
        }
    }
}
