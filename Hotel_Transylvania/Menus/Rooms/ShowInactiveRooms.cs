using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowInactiveRooms : IShowInactiveRooms
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I SHOWINACTIVE ROOMS");
            Console.ReadKey();

        }
    }
}
