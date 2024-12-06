using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using Hotel_Transylvania.Menus.MenuServices;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ReactivateGuest(
        IPrintInactiveGuests printInactiveGuests) : IReactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var numberOfInactiveGuests = Guest.ListOfAllGuests
                .Where(g => g.IsGuestActive == false)
                .Count();

            if (numberOfInactiveGuests >= 1)
            {
                Console.WriteLine("Chose a guest to reactivate..");
                printInactiveGuests.ExecuteXY(40, 9);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Enter GuestID of the guest you want to reactivate..");
                Console.Write("GuestID: ");
                var guestToReactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write("\nPress 'Enter' to save..");
                Console.ReadKey();

                Guest.ListOfAllGuests
                    .First(g => g.GuestID == guestToReactivate)
                    .IsGuestActive = true;
            }
            else
            {
                Console.WriteLine("There are no inactive guests in the system." +
                    "\nPress any key to go back.");
                Console.WriteLine(numberOfInactiveGuests);
                Console.ReadKey();
                return;
            }

            Console.ReadKey();
        }
    }
}
