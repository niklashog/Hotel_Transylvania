using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces
{
    public interface INavigateReservationsMenu
    {
        public void MenuNavigator(string[] menuItems, ref bool isRunning, ref int selectedIndex);
    }
}
