namespace Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces
{
    public interface INavigateRoomsMenu
    {
        public void MenuNavigator(string[] menuItems, ref bool isRunning, ref int selectedIndex);
    }
}
