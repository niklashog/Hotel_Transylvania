﻿using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
