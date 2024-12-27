using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using System;



namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteUpdateReservationMenu(
        IMainMenu mainMenu,
        IUpdateReservation updateReservation) : IExecuteUpdateReservationMenu
    {
        public void Execute(int index)
        {
            switch (index)
            {
                case 0:
                    updateReservation.ChangeRoomNumber();
                    break;
                case 1:
                    updateReservation.ChangeDates();
                    break;
                case 2:
                    updateReservation.UpdateAdditionalBedding();
                    break;
                case 3:
                    mainMenu.Execute();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
