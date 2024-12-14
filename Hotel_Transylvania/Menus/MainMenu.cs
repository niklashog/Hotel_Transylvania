using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using System;

namespace Hotel_Transylvania.Menus
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
                menuNavigation.MenuNavigator(menuItems, ref selectedIndex);
            }
        }
    }
}