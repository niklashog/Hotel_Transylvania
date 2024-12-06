﻿using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;

namespace Hotel_Transylvania.Menus.Guests
{
    public class ShowInactiveGuests(
        IPrintInactiveGuests printInactiveGuests) : IShowInactiveGuests
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();
            Console.WriteLine("I SHOW INACTIVE GUESTS:");

            Guest.ListOfAllGuests
                .Where(g => g.IsGuestActive == false)
                .ToList()
                .ForEach((g => Console.WriteLine($"{g.GuestID} {g.FirstName} {g.Surname}")));

            Console.ReadKey();
        }
    }
}
