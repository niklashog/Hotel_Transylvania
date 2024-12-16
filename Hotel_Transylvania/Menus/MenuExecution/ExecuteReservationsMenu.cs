using Hotel_Transylvania.Interfaces.ControllerInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteReservationsMenu(
    IAddReservation addReservation,
    IChangeReservation changeReservation,
    ICancelReservation cancelReservation,
    IShowReservations showReservations,
    IMainMenu mainMenu) : IExecuteReservationsMenu
    {
        public void Execute(int index)
        {
            switch (index)
            {
                case 0:
                    addReservation.Execute();
                    break;
                case 1:
                    changeReservation.Execute();
                    break;
                case 2:
                    showReservations.Execute();
                    break;
                case 3:
                    cancelReservation.Execute();
                    break;
                case 4:
                    mainMenu.Execute();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
