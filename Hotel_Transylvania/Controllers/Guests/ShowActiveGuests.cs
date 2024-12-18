using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.DisplayInterfaces;
using Hotel_Transylvania.Data;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowActiveGuests(
        IGuestService guestService) : IShowActiveGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            var dbContext = ApplicationDbContext.GetDbContext();


            var xcoord = 2;
            var ycoord = 9;
            guestService.DisplayActiveGuests(xcoord, ycoord, dbContext);

            Console.ReadKey();
        }
    }
}
