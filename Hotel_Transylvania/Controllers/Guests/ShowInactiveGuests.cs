using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Data;
using Hotel_Transylvania.Services;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowInactiveGuests(
        IGuestService guestService) : IShowInactiveGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            var xcoord = 2;
            var ycoord = 9;
            guestService.GetInctiveGuests(xcoord, ycoord);

            Console.ReadKey();
        }
    }
}
