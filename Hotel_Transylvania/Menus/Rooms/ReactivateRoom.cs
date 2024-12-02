using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ReactivateRoom : IReactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I REACTIVATE ROOM");
            Console.ReadKey();

        }
    }
}
