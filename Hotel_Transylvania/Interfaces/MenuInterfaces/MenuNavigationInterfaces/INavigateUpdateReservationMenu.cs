using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.MenuInterfaces.MenuNavigationInterfaces
{
    public interface INavigateUpdateReservationMenu
    {
        public void MenuNavigator(string[] menuItems, ref int selectedIndex);
    }
}
