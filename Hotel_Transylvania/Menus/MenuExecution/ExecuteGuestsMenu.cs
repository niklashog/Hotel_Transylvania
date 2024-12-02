using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteGuestsMenu(
    IDeactivateGuest deactivateGuest,
    IReactivateGuest reactivateGuest,
    IRegisterGuest registerGuest,
    IShowAllGuests showAllGuests,
    IShowInactiveGuests showInactiveGuests,
    IUpdateGuest updateGuest,
    IMainMenu mainMenu) : IExecuteGuestsMenu
    {
        public void Execute(int index, ref bool isRunning)
        {
            switch (index)
            {
                case 0:
                    registerGuest.Execute();
                    break;
                case 1:
                    updateGuest.Execute();
                    break;
                case 2:
                    showAllGuests.Execute();
                    break;
                case 3:
                    deactivateGuest.Execute();
                    break;
                case 4:
                    reactivateGuest.Execute();
                    break;
                case 5:
                    showInactiveGuests.Execute();
                    break;
                case 6:
                    mainMenu.Execute();
                    break;

                default:
                    Console.WriteLine("Felaktigt val.");
                    break;
            }
        }
    }
}
