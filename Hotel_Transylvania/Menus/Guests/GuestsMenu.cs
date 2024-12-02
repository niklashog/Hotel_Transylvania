using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Graphics;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.Guests
{
    public class GuestsMenu : IGuestsMenu
    {
        public void Execute()
        {
            var executeMenuOption = MainFactory.Resolve<IExecuteGuestsMenu>();
            var menuNavigation = MainFactory.Resolve<INavigateGuestsMenu>();
            var menuHighlight = MainFactory.Resolve<IMenuHighlight>();

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
