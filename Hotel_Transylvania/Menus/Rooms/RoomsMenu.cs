using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class RoomsMenu : IRoomsMenu
    {
        public void Execute()
        {
            var executeMenuOption = MainFactory.Resolve<IExecuteRoomsMenu>();
            var menuNavigation = MainFactory.Resolve<INavigateRoomsMenu>();
            var menuHighlight = MainFactory.Resolve<IMenuHighlight>();

            Console.CursorVisible = false;
            string[] menuItems = {
                "Show all rooms", "Update a room",
                "Deactivate a room", "Reactivate a room",
                "Show inactive rooms", "Back to main menu" };

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
