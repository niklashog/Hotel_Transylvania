using Hotel_Transylvania.Display;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces;

namespace Hotel_Transylvania.Menus
{
    public class UpdateReservationMenu : IUpdateReservationMenu
    {
        public void Execute()
        {
            var executeMenuOption = MainFactory.Resolve<IExecuteUpdateReservationMenu>();
            var menuNavigation = MainFactory.Resolve<INavigateUpdateReservationMenu>();
            var menuHighlight = MainFactory.Resolve<IMenuHighlight>();

            Console.CursorVisible = false;
            string[] menuItems = {
                "Change Room Number", "Change Reservation Dates",
                "Update Additional bedding", "Back to main menu" };

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
