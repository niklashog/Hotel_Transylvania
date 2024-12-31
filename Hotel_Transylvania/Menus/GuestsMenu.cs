using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;

namespace Hotel_Transylvania.Menus
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
                "Show active guests", "Deactivate guest",
                "Reactivate guest", "Show inactive guests",
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
