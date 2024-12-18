using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;
using Hotel_Transylvania.Data;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ReactivateGuest(
        IGuestService guestService) : IReactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var dbContext = ApplicationDbContext.GetDbContext();


            if (guestService.GetAllGuests(dbContext)
                .Where(g => g.IsGuestActive == false)
                .ToList()
                .Count >= 1)
            {
                var xcoord = 45;
                var ycoord = 9;
                guestService.GetInctiveGuests(xcoord, ycoord, dbContext);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Make choice by Guest ID..");
                Console.Write("Guest to reactivate: ");
                var guestToReactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write("\nPress 'Enter' to save..");

                Console.ReadKey();
                guestService.ReActivateGuest(guestToReactivate, dbContext);

            }
            else
            {
                Console.WriteLine("There are no inactive guests in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
        }
    }
}
