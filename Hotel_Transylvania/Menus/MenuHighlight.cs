using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus
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
                    Console.WriteLine($"<·> {menuItems[i]}");
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
