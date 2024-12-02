using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MainMenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Main
{
    public class MainMenu(
        INavigateMainMenu menuNavigation,
        IMenuHighlight menuHighlight) : IMainMenu
    {
        public void Execute()
        {
            Console.CursorVisible = false;
            string[] menuItems = { "Rooms", "Guests", "Reservations", "Exit" };

            int selectedIndex = 0;
            bool isRunning = true;


            while (isRunning)
            {
                Console.Clear();
                DisplayLogo.Paint();

                menuHighlight.MenuHighlighter(menuItems, ref selectedIndex);
                menuNavigation.MenuNavigator(menuItems, ref isRunning, ref selectedIndex);
            }
        }
    }
}