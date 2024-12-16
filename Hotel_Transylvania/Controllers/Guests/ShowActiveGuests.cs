using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.FakeDatabase;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowActiveGuests(
        IGuestService guestService) : IShowActiveGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            var xcoord = 2;
            var ycoord = 9;
            guestService.GetActiveGuests(xcoord, ycoord);

            Console.ReadKey();
        }
    }
}
