using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteReservationsMenu(
    INewReservation newReservation,
    IChangeReservation changeReservation,
    ICancelledReservations cancelReservation,
    IShowReservations showReservations,
    ICancelledReservations cancelledReservations,
    IMainMenu mainMenu) : IExecuteReservationsMenu
    {
        public void Execute(int index)
        {
            switch (index)
            {
                case 0:
                    newReservation.Execute();
                    break;
                case 1:
                    changeReservation.Execute();
                    break;
                case 2:
                    cancelReservation.Execute();
                    break;
                case 3:
                    showReservations.Execute();
                    break;
                case 4:
                    cancelledReservations.Execute();
                    break;
                case 5:
                    mainMenu.Execute();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
