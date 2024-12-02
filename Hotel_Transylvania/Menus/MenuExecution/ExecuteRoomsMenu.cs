using Hotel_Transylvania.Interfaces.MenuInterfaces.MainMenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;


namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteRoomsMenu(
    IDeactivateRoom deactivateRoom,
    IReactivateRoom reactivateRoom,
    IShowAllRooms showAllRooms,
    IShowInactiveRooms showInactiveRooms,
    IUpdateRoom updateRoom,
    IMainMenu mainMenu) : IExecuteRoomsMenu
    {
        public void Execute(int index, ref bool isRunning)
        {
            switch (index)
            {
                case 0:
                    showAllRooms.Execute();
                    break;
                case 1:
                    updateRoom.Execute();
                    break;
                case 2:
                    deactivateRoom.Execute();
                    break;
                case 3:
                    reactivateRoom.Execute();
                    break;
                case 4:
                    showInactiveRooms.Execute();
                    break;
                case 5:
                    mainMenu.Execute();
                    break;
                default:
                    Console.WriteLine("Felaktigt val.");
                    break;
            }
        }
    }
}
