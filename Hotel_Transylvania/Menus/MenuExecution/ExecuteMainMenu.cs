using Hotel_Transylvania.Interfaces.MenuInterfaces.GuestsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.ReservationsInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;


namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteMainMenu(
        IRoomsMenu rooms,
        IGuestsMenu guests,
        IReservationsMenu bookings) : IExecuteMainMenu
    {

        public void Execute(int index, ref bool isRunning)
        {
            switch (index)
            {
                case 0:
                    rooms.Execute();
                    break;
                case 1:
                    guests.Execute();
                    break;
                case 2:
                    bookings.Execute();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Felaktigt val.");
                    break;
            }
        }
    }
}
