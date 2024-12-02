﻿using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus
{
    public class ReservationsMenu : IReservationsMenu
    {
        public void Execute()
        {
            var executeMenuOption = ClassFactory.Resolve<IExecuteReservationsMenu>();
            var menuNavigation = ClassFactory.Resolve<INavigateReservationsMenu>();
            var menuHighlight = ClassFactory.Resolve<IMenuHighlight>();

            Console.CursorVisible = false;
            string[] menuItems = { 
                "New reservation", "Change a reservation",
                "Cancel a reservation", "Show all reservations", 
                "Show cancelled reservations", "Back to main menu" };

            int selectedIndex = 0;
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                DisplayLogo.Paint();

                menuHighlight.MenuHighlighter(menuItems, ref selectedIndex);
                menuNavigation.MenuNavigator(menuItems, ref isRunning, ref selectedIndex);
            }
            Console.ReadKey();
        }
    }
}
