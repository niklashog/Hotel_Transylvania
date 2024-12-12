using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class UpdateGuest(
        IGuestService guestService) : IUpdateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var xcoord = 45;
            var ycoord = 8;
            guestService.DisplayActiveGuests(xcoord, ycoord);

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

            guestService.DisplaySingleActiveGuest(guestToUpdate, xcoord, ycoord);
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

            guestService.UpdateGuestDetails(guestToUpdate, updatedGuestDetails);
            Console.ReadKey();
        }
    }
}
