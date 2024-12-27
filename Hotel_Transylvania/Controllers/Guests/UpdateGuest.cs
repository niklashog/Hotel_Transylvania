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
            Console.WriteLine("Make choice by Guest ID..");
            Console.Write("Guest to update: ");
            var guestToUpdate = Convert.ToInt32(Console.ReadLine());

            Console.CursorVisible = false;
            Console.Write($"\nPress 'Enter' to edit guest #{guestToUpdate}..");
            Console.ReadKey();

            Console.Clear();
            DisplayLogo.Paint();

            guestService.PrintGuestDetails(guestToUpdate, dbContext);


            string firstName;
            string firstNamePattern = @"^[\p{L}]+$";
            while (true)
            {
                Console.Write("First Name: ");
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
                Console.Write("Surname: ");
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
                Console.Write("E-mail: ");
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

            var updatedGuestDetails = new string[]
            {
                firstName,
                surname,
                email,
                phone
            };

            guestService.UpdateGuestDetails(guestToUpdate, updatedGuestDetails, dbContext);
        }
    }
}
