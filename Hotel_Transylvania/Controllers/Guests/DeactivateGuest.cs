using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ModelsInterfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Models;
using System.Threading.Channels;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class DeactivateGuest(
        IGuestService guestService) : IDeactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            if (guestService.GetAllGuests()
                .Where(g => g.IsGuestActive)
                .ToList()
                .Count >= 1)
            {
                var xcoord = 45;
                var ycoord = 9;
                guestService.DisplayActiveGuests(xcoord, ycoord);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Make choice by Guest ID..");
                Console.Write("Guest to deactivate: ");
                var guestToDeactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write($"\nPress 'Enter' to deactivate guest {guestToDeactivate}..");

                Console.ReadKey();
                guestService.RemoveGuest(guestToDeactivate);
            }
            else
            {
                Console.WriteLine("There are no active guests in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
        }
    }

}
