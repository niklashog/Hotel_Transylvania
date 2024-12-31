using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;

namespace Hotel_Transylvania.Menus
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
                "Show active rooms", "Update a room",
                "Deactivate a room", "Reactivate a room",
                "Show inactive rooms", "Register new room",
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
