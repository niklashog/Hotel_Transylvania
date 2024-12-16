﻿using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.CalendarsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;

namespace Hotel_Transylvania.Menus
{
    public class ReservationMenu : IReservationMenu
    {
        public void Execute()
        {
            var executeMenuOption = MainFactory.Resolve<IExecuteReservationsMenu>();
            var menuNavigation = MainFactory.Resolve<INavigateReservationsMenu>();
            var menuHighlight = MainFactory.Resolve<IMenuHighlight>();

            Console.CursorVisible = false;
            string[] menuItems = {
                "Make new reservation", "Update reservation",
                "Show active reservations", "Cancel reservation",
                "Back to main menu" };

            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                DisplayLogo.Paint();

                menuHighlight.MenuHighlighter(menuItems, ref selectedIndex);
                menuNavigation.MenuNavigator(menuItems, ref selectedIndex);
            }
        }
    }
}