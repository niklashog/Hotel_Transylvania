﻿using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class UpdateGuest : IUpdateGuest
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I UPDATE GUEST BUT" +
                "I AM UNDER CONSTRUCTION");
            Console.ReadKey();
        }
    }
}
