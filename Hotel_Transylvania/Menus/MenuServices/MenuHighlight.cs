using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuServicesInterfaces;

namespace Hotel_Transylvania.Menus.MenuServices
{
    public class MenuHighlight : IMenuHighlight
    {
        public void MenuHighlighter(string[] menuItems, ref int selectedIndex)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"·> {menuItems[i]}");
                    Console.ResetColor();
                }

                else
                {
                    Console.WriteLine($"  {menuItems[i]}");
                }
            }
        }
    }
}
