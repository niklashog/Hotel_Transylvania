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
    public class GuestsMenu : IGuestsMenu
    {
        public void Execute()
        {
            var executeMenuOption = ClassFactory.Resolve<IExecuteGuestsMenu>();
            var menuNavigation = ClassFactory.Resolve<INavigateGuestsMenu>();
            var menuHighlight = ClassFactory.Resolve<IMenuHighlight>();

            Console.CursorVisible = false;
            string[] menuItems = {
                "Register new guest", "Update guest information",
                "Show all guests", "Deactivate guest",
                "Reactivate  guest", "Show all inactive guests",
                "Back to main menu" };

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
