using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;

namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteGuestsMenu(
    IDeactivateGuest deactivateGuest,
    IReactivateGuest reactivateGuest,
    IRegisterGuest registerGuest,
    IShowActiveGuests showAllGuests,
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
