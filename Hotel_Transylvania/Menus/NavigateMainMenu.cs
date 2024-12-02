﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Interfaces;

namespace Hotel_Transylvania.Menus
{
    public class NavigateMainMenu(
        IExecuteMainMenu executeMenuOption) : INavigateMainMenu
    {

        public void MenuNavigator(string[] menuItems, ref bool isRunning, ref int selectedIndex)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    executeMenuOption.Execute(
                        selectedIndex,
                        ref isRunning);
                    break;
            }
        }
    }
}
