namespace Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces
{
    public interface INavigateGuestsMenu
    {
        public void MenuNavigator(string[] menuItems, ref bool isRunning, ref int selectedIndex);
    }
}
