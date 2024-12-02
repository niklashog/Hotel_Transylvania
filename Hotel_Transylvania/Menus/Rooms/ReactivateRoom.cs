using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ReactivateRoom : IReactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("I REACTIVATE ROOM");
            Console.ReadKey();

        }
    }
}
