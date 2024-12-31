using Hotel_Transylvania.Interfaces.MenuInterfaces;
using Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces;



namespace Hotel_Transylvania.Menus.MenuExecution
{
    public class ExecuteMainMenu(
        IRoomsMenu rooms,
        IGuestsMenu guests,
        IReservationsMenu reservations) : IExecuteMainMenu
    {
        public void Execute(int index)
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
                    reservations.Execute();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
