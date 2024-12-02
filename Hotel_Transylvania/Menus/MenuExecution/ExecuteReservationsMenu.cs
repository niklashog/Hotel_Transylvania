using Hotel_Transylvania.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Execute(int index, ref bool isRunning)
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
                    Console.WriteLine("Felaktigt val.");
                    break;
            }
        }
    }
}
