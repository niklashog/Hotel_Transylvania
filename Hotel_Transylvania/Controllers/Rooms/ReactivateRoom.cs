using Hotel_Transylvania.Display;
using Hotel_Transylvania.Interfaces.MenuInterfaces.RoomsInterfaces;
using Hotel_Transylvania.Interfaces.ServicesInterfaces;
using Hotel_Transylvania.Models;
using Hotel_Transylvania.Services;

namespace Hotel_Transylvania.Menus.Rooms
{
    public class ReactivateRoom(
        IRoomService roomService) : IReactivateRoom
    {
        public void Execute()
        {
            Console.Clear();
            DisplayLogo.Paint();

            if (roomService.GetAllRooms()
                .Where(g => g.IsRoomActive == false)
                .ToList()
                .Count >= 1)
            {
                var xcoord = 45;
                var ycoord = 9;
                roomService.GetInactiveRooms(xcoord, ycoord);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Make choice by Room number..");
                Console.Write("Room to reactivate: ");
                var roomToReactivate = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                Console.Write("\nPress 'Enter' to save..");

                Console.ReadKey();
                roomService.ReActivateRoom(roomToReactivate);

            }
            else
            {
                Console.WriteLine("There are no inactive rooms in the system." +
                    "\nPress any key to go back.");
                Console.ReadKey();
                return;
            }
        }
    }
}
