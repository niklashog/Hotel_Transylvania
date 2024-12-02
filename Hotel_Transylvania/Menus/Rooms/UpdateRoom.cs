using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class UpdateRoom : IUpdateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I UPDATE ROOM");
            Console.ReadKey();

        }
    }
}
