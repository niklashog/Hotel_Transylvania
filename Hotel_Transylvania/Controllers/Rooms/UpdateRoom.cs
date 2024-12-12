using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class UpdateRoom : IUpdateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I UPDATE ROOM BUT" +
                "I AM UNDER CONSTRUCTION");
            Console.ReadKey();

        }
    }
}
