﻿using Hotel_Transylvania.Interfaces.ControllerInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;

namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteReservationsMenu(
    IAddReservation addReservation,
    IUpdateReservation changeReservation,
    IUpdateReservationMenu updateReservation,
    IDeactivateReservation cancelReservation,
    IShowReservations showReservations,
    IShowInactiveReservations showInactiveReservations,
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
                    updateReservation.Execute();
                    break;
                case 2:
                    showReservations.Execute();
                    break;
                case 3:
                    showInactiveReservations.Execute();
                    break;
                case 4:
                    cancelReservation.Execute();
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
