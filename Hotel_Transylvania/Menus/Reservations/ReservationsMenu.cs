﻿using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Reservations
{
    public class ReservationsMenu : IReservationsMenu
    {
        public void Execute()
        {
            var executeMenuOption = MainFactory.Resolve<IExecuteReservationsMenu>();
            var menuNavigation = MainFactory.Resolve<INavigateReservationsMenu>();
            var menuHighlight = MainFactory.Resolve<IMenuHighlight>();

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
