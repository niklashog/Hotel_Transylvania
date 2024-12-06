using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using System.Threading.Channels;

namespace Hotel_Transylvania.Menus.Guests
{
    public class DeactivateGuest(
        IPrintActiveGuests printActiveGuests) : IDeactivateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var guest = MainFactory.Resolve<IGuest>();

            if (Guest.ListOfAllGuests
                .Where(g => g.IsGuestActive = true)
                .ToList()
                .Count >= 1)
            {
                printActiveGuests.ExecuteXY(40, 9);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Enter GuestID of the guest you want to deactivate..");
                Console.Write("GuestID: ");
                var guestToDeactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write($"\nPress 'Enter' to deactivate guest {guestToDeactivate}..");
                Console.ReadKey();

                Guest.ListOfAllGuests
                    .First(g => g.GuestID == guestToDeactivate)
                    .IsGuestActive = false;
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
