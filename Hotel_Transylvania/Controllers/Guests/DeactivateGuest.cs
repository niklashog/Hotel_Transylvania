using Hotel_Transylvania.Data;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
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

            using var dbContext = ApplicationDbContext.GetDbContext();


            if (guestService.GetAllGuests(dbContext)
                .Where(g => g.IsGuestActive)
                .ToList()
                .Count >= 1)
            {
                guestService.DisplayActiveGuests(dbContext);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("Make choice by Guest ID..");
                Console.Write("Guest to deactivate: ");
                var guestToDeactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;

                Console.SetCursorPosition(0, 7);
                Console.WriteLine($"\nPress 'Enter' to deactivate guest #{guestToDeactivate}..");
                Console.Write(new string(' ', Console.WindowWidth));

                Console.ReadKey();
                Console.SetCursorPosition(0, 7);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.Write(new string(' ', Console.WindowWidth));
                guestService.RemoveGuest(guestToDeactivate, dbContext);
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
