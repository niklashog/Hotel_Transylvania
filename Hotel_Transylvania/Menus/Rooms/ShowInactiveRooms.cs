﻿using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ShowInactiveRooms : IShowInactiveRooms
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("I SHOWINACTIVE ROOMS");
            Console.ReadKey();

        }
    }
}
