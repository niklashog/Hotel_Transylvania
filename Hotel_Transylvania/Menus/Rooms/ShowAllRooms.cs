using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Interfaces;


namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowAllRooms : IShowAllRooms
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("I SHOW ALL ROOMS");
            Console.ReadKey();

        }
    }
}
