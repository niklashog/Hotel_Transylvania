using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowInactiveRooms(
        IRoomService roomService) : IShowInactiveRooms
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            var xcoord = 2;
            var ycoord = 9;
            roomService.GetInactiveRooms(xcoord, ycoord);

            Console.ReadKey();
        }
    }
}
