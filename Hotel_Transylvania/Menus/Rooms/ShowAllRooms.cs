using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;


namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowAllRooms : IShowAllRooms
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I SHOW ALL ROOMS");
            Console.ReadKey();

        }
    }
}
