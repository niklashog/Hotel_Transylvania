﻿using Hotel_Transylvania.Data;
using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowActiveGuests(
        IGuestService guestService) : IShowActiveGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            using var dbContext = ApplicationDbContext.GetDbContext();

            guestService.DisplayActiveGuests(dbContext);

            Console.ReadKey();
        }
    }
}
