using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Data;

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

            var xcoord = 45;
            var ycoord = 8;
            guestService.DisplayActiveGuests(dbContext);

            Console.CursorVisible = true;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Make choice by Guest ID..");
            Console.SetCursorPosition(2, 9);
            Console.Write("Guest to update: ");
            var guestToUpdate = Convert.ToInt32(Console.ReadLine());

            Console.CursorVisible = false;
            Console.Write($"\nPress 'Enter' to edit guest #{guestToUpdate}..");
            Console.ReadKey();

            Console.Clear();
            DisplayLogo.Paint();

            guestService.PrintGuestDetails(guestToUpdate, xcoord, ycoord, dbContext);
            Console.CursorVisible = true;
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Enter guest details..");
            Console.SetCursorPosition(2, 9);
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.SetCursorPosition(2, 10);
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            Console.SetCursorPosition(2, 11);
            Console.Write("E-mail: ");
            var email = Console.ReadLine();
            Console.SetCursorPosition(2, 12);
            Console.Write("Phone number: ");
            var phone = Console.ReadLine();
            Console.CursorVisible = false;
            Console.SetCursorPosition(2, 14);
            Console.Write("\nPress 'Enter' to save..");
            Console.ReadKey();

            var updatedGuestDetails = new string[]
            {
                firstName,
                surname,
                email,
                phone,
            };

            guestService.UpdateGuestDetails(guestToUpdate, updatedGuestDetails, dbContext);
            Console.ReadKey();
        }
    }
}
