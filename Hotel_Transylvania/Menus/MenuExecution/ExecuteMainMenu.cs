using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Transylvania.Factories;
using Hotel_Transylvania.Interfaces;


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
